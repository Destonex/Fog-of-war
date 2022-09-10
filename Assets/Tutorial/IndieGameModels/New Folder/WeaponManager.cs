using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    /*public GameObject playerCam;
    public float range = 100f;
    public GameObject prefab;*/
    public GameObject sniper;
    public GameObject knife;
    public GameObject grenade;

    public Transform shootPoint;
    public Transform targetLook;
    public GameObject cameraMain;
    public GameObject decal;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        sniper.SetActive(true);
        knife.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("1")){
            sniper.SetActive(true);
            knife.SetActive(false);
        }
        else if(Input.GetKeyDown("2")){
            knife.SetActive(true);
            sniper.SetActive(false);
        }

        if(sniper.activeSelf == true)
            sniperMethod();
        else 
            knifeMethod();
  
    }
    public void Shoot()
    {
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }
    /*void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
            Debug.Log("hit");
    }*/
    public void sniperMethod(){
                /*if(Input.GetKey("w"))
        {
            if(!animationSniper.IsPlaying("Fire") && !animationSniper.IsPlaying("Idle")){
                //animationSniper.Stop();
                animationSniper.Play("Walk");
            }
        }*/

       /* else if(Input.GetKeyDown("shift"))
        {
          animationSniper.Play("Run");  
        }
        else
        {
            animationSniper.Play("Idle");
        }*/
        
        if(!sniper.GetComponent<Animation>().IsPlaying("Fire")){
            if(!sniper.GetComponent<Animation>().IsPlaying("Reload2")){
                sniper.GetComponent<Animation>().Play("Idle");

            }
            /*if(Input.GetKeyDown("g"))
            {
                sniper.GetComponent<Animation>().Stop();
                sniper.SetActive(false);
                grenadeMethod();
                if(grenade.GetComponent<Animation>().IsPlaying("Throw_grenade"))
                    sniper.SetActive(true);
            }*/
            if(Input.GetKeyDown("r")){
                sniper.GetComponent<Animation>().Stop();
                sniper.GetComponent<Animation>().Play("Reload2");
            }
            if(Input.GetButtonDown("Fire"))
            {
                sniper.GetComponent<Animation>().Stop();
                sniper.GetComponent<Animation>().Play("Fire");
                Shoot();  
            }
        }


        shootPoint.LookAt(targetLook);
        Vector3 origin = shootPoint.position;
        Vector3 dir = targetLook.position;    

        RaycastHit hit;

        Debug.DrawLine(origin, dir, Color.black);
        Debug.DrawLine(cameraMain.transform.position, dir, Color.black);
    
       /* if(Physics.Linecast(origin, dir, out hit))
        {
            //decal.SetActive(true);
            decal.transform.position = hit.point + hit.normal * 0.01f;
            decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
        }*/

        if(Physics.Raycast(targetLook.transform.position, targetLook.transform.forward, out hit)){

            decal.transform.position = hit.point + hit.normal * 0.01f;
            decal.transform.rotation = Quaternion.LookRotation(-hit.normal);
        }
    }

    public void knifeMethod(){
        if(!knife.GetComponent<Animation>().IsPlaying("AttackKnife")){
            knife.GetComponent<Animation>().Play("IdleKnife");
            /*if(Input.GetKeyDown("g"))
            {
                knife.GetComponent<Animation>().Stop();
                knife.SetActive(false);
                grenade.SetActive(true);
                grenadeMethod();
                if(grenade.GetComponent<Animation>().IsPlaying("Throw_grenade")){
                    knife.SetActive(true);
                    grenade.SetActive(false);
                }
            }*/
            if(Input.GetButtonDown("Fire"))
            {
                knife.GetComponent<Animation>().Stop();
                knife.GetComponent<Animation>().Play("AttackKnife");
            }
        }
    }
    public void grenadeMethod()
    {      
                grenade.GetComponent<Animation>().Stop();
                grenade.GetComponent<Animation>().Play("Throw_grenade");
    }
}
