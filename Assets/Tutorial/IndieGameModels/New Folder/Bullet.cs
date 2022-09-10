using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int Speed;
    Vector3 lastPos;
    public GameObject decal;
    public GameObject bullet;
    
    private float damage = 10f;
    //public Colider colider;
    void Start()
    {
        lastPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);    
        
        RaycastHit hit;

        Debug.DrawLine(lastPos, transform.position);

        if(Physics.Linecast(lastPos, transform.position, out hit))
        {
            damage = Random.Range(15, 30);
            Health_Emeny target = hit.transform.GetComponent<Health_Emeny>();
            if(target != null)
                target.TakeDamage(damage); 

            if(hit.transform.tag != "AI")
            {
                //bullet.AddComponent<SphereCollider>();
                //hit.transform.position = new Vector3(hit.transform.position.x, hit.transform.position.y, hit.transform.position.z * 1 * Time.deltaTime);
                //hit.Translate(Vector3.forward * 2 * Time.deltaTime);
                print(hit.transform.name);

                GameObject d = Instantiate<GameObject>(decal);
                d.transform.position = hit.point + hit.normal * 0.001f;
                d.transform.rotation = Quaternion.LookRotation(-hit.normal);
                d.transform.SetParent(hit.transform);

                Destroy(d, 10);
            }
            Destroy(gameObject,0.05f);
        }

        /*if(lastPos == gameObject.GetComponent<Transform>().position)
            Destroy(gameObject);*/
        
        lastPos = transform.position;
    }
}
