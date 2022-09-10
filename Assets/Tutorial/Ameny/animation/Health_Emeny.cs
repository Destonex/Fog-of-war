using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Emeny : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health = 100f;
    
    //public Text hp;

    public GameObject bullet;

    //public GameObject sniper;
    //public GameObject knife;

    public void TakeDamage(float amount){
        Health = Health - amount;
        if(Health<=0)
            Die();
    }

    private void Die() {
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
       // hp.text = string.Format("{0:0}", Health);
        /*if(Health<=0f)
            Die();*/
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Button" )
            Health = Health - 15f;
    }

    private void OnTriggerStay() {
        //if(Input.GetButtonDown("Fire1")){
            Health = Health - 15f;//Random.Range(15, 30);
        //}
    }//*/
}
