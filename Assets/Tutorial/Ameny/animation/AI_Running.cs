using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Running : MonoBehaviour
{
    [Header("Для поиска")]
    [Range(0, 360)] public float ViewAngle = 90f;
    public float ViewDistance = 15f;
    public float DetectionDistance = 3f;
    [Header("Для стрельбы")]
    [Range(0, 360)] public float ShootAngle = 30f;
    public float ShootDistance = 7f;
    public int Damage;
    [Header("Для Прицелевания")]
    [Range(0, 360)] public float AimAngle = 30f;
    public float AimDistance = 7f;
    [Header("Объекты")]
    public Transform EnemyEye;
    public Transform Target;
    [Header("Передвижение")]
    public bool Running;
    //public GameObject Player;


    private float timer;
    private NavMeshAgent agent;
    private float rotationSpeed;
    private Transform agentTransform;
    //public Patrol patrol;



    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        rotationSpeed = agent.angularSpeed;
        agentTransform = agent.transform;
        //gameObject.GetComponent<Animator>().SetBool("Walk", true);
    }
    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(Target.transform.position, agent.transform.position);

        if (distanceToPlayer <= DetectionDistance || IsInView())
        {
            //gameObject.GetComponent<Patrol>().SetActive(false);
            ////////////RotateToTarget();
            //gameObject.GetComponent<Animator>().SetBool("Rotate_rigth", true);
            RotateToTarget();
            if (Running == true)
            {
                if (IsInView())
                {
                    MoveToTarget();
                    gameObject.GetComponent<Animator>().SetBool("Walk", true);
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("Walk", false);
                }

                if (IsAimInView())
                {
                    gameObject.GetComponent<Animator>().SetBool("Aim", true);
                    if (IsShootInView())
                    {

                        gameObject.GetComponent<Animator>().SetBool("Fire", true);
                        onFire();
                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("Fire", false);
                    }
                }
                else
                {
                    gameObject.GetComponent<Animator>().SetBool("Aim", false);
                }
            }
            else
            {
                    //patrol.SetActive(false);
                    //gameObject.GetComponent<Animator>().SetBool("Aim", true);
                    if (IsShootInView()||(IsShootInView() && distanceToPlayer <= DetectionDistance))
                    {
                        gameObject.GetComponent<Animator>().SetBool("Shoot", true);
                        onFire();
                    }
                    else
                    {
                        gameObject.GetComponent<Animator>().SetBool("Shoot", false);
                    }
              /*  else
                {
                    gameObject.GetComponent<Animator>().SetBool("Aim", false);
                }*/
            }
        }
       // else
       /*{
            gameObject.GetComponent<Animator>().SetBool("Fire", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
        }*/
        // OnDrawGizmos();
    }

    private bool IsInView() // true если цель видна
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, out hit, ViewDistance))
        {
            if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= ViewDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsShootInView() // true если цель видна Shoot
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, out hit, ShootDistance))
        {
            if (realAngle < ViewAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= ShootDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsAimInView() // true если цель видна Shoot
    {
        float realAngle = Vector3.Angle(EnemyEye.forward, Target.position - EnemyEye.position);
        RaycastHit hit;
        if (Physics.Raycast(EnemyEye.transform.position, Target.position - EnemyEye.position, out hit, AimDistance))
        {
            if (realAngle < AimAngle / 2f && Vector3.Distance(EnemyEye.position, Target.position) <= AimDistance && hit.transform == Target.transform)
            {
                return true;
            }
        }
        return false;
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

    private void MoveToTarget() // устанвливает точку движения к цели
    {
        agent.SetDestination(Target.position);
    }

    void OnDrawGizmos()//Линии рабочий вариант
    {
        Gizmos.color = Color.red;
        Vector3 left = EnemyEye.position + Quaternion.Euler(new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
        Vector3 right = EnemyEye.position + Quaternion.Euler(-new Vector3(0, ViewAngle / 2f, 0)) * (EnemyEye.forward * ViewDistance);
        Gizmos.DrawLine(EnemyEye.position, left);
        Gizmos.DrawLine(EnemyEye.position, right);

        Gizmos.color = Color.yellow;
        Vector3 lft = EnemyEye.position + Quaternion.Euler(new Vector3(0, ShootAngle / 2f, 0)) * (EnemyEye.forward * ShootDistance);
        Vector3 rht = EnemyEye.position + Quaternion.Euler(-new Vector3(0, ShootAngle / 2f, 0)) * (EnemyEye.forward * ShootDistance);
        Gizmos.DrawLine(EnemyEye.position, lft);
        Gizmos.DrawLine(EnemyEye.position, rht);

        Gizmos.color = Color.blue;
        Vector3 l = EnemyEye.position + Quaternion.Euler(new Vector3(0, AimAngle / 2f, 0)) * (EnemyEye.forward * AimDistance);
        Vector3 r = EnemyEye.position + Quaternion.Euler(-new Vector3(0, AimAngle / 2f, 0)) * (EnemyEye.forward * AimDistance);
        Gizmos.DrawLine(EnemyEye.position, l);
        Gizmos.DrawLine(EnemyEye.position, r);
    }

    void onFire(){
        timer += 1 * Time.deltaTime;
        if (timer >= 1.2f)
        {
            Target.GetComponent<Health_Player>().Health -= Random.Range(10, 20);
            timer = 0;
        }
    }
}