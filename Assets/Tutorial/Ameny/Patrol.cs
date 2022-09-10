using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    float timer;
    int pointIndex = 0;
    public List<Transform> points = new List<Transform>();
    public NavMeshAgent agent;

    public Transform agentTransform;
    public Transform Target;
    
    private float rotationSpeed;
    void Start()
    {
       timer = 0;
       Transform pointObject = GameObject.FindGameObjectWithTag("Points").transform;
        foreach (Transform item in pointObject)
            points.Add(item);
        Target = points[1];
          
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
    
        rotationSpeed = agent.angularSpeed;
        agentTransform = agent.transform;
        //agent = animator.GetComponent<NavMeshAgent>();
        agent.SetDestination(points[0].position);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    void Update()
    {
        RotateToTarget();
       if(agent.remainingDistance <= agent.stoppingDistance){
           Target = points[pointIndex]; 
            agent.SetDestination(points[pointIndex++].position);
            //gameObject.GetComponent<Animator>().SetBool("Walk", true);
            
       }

        timer += Time.deltaTime;    
        if(pointIndex == points.Count)
            pointIndex = 0;
        //if(timer > 10)
            //animator.SetBool("IsPatrolling", false);
    }

    private void RotateToTarget() // поворачивает в стороно цели со скоростью rotationSpeed
    {
        Vector3 lookVector = Target.position - agentTransform.position;
        lookVector.y = 0;
        if (lookVector == Vector3.zero) return;
        agentTransform.rotation = Quaternion.RotateTowards
            (
                agentTransform.rotation,
                Quaternion.LookRotation(lookVector , Vector3.up),
                rotationSpeed * Time.deltaTime
            );
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
   /* override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       agent.SetDestination(agent.transform.position);
    }//*/

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
