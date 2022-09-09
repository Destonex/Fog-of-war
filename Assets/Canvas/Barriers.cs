using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;
using System.Text.RegularExpressions;
public class Barriers : MonoBehaviour
{
    public Text barriers;
    public string text_Barriers;
    public List<Collider> barr;
    private float fd = 50.0f;
    //DateTime tf;
    private float tf;
   // DateTime t;
   private float t;
    void Start()
    {
        //barriers.text = "";
    }
    void Update()
    {
       // barriers.text = " 0";
        //barr.Any().OnTriggerEnter(Collider col);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            barriers.text = text_Barriers;
            
            //text_Barriers.col = col;
         //   text_Barriers.OnGUI();
        }
    }

    IEnumerator OnTriggerStay(Collider col)
    {
        //TimeReturn(fd);
        
        if (col.tag == "Player"){
             yield return new WaitForSeconds(2);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            //text_Barriers.col = col;
         //   text_Barriers.OnGUI();

        
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            barriers.text = "";
            //text_Barriers.col = col;
         //   text_Barriers.OnGUI();
        }
    }
    float TimeReturn(float fd){
        if(fd != 0)
        fd = fd - Time.deltaTime;
        return fd;
    }

}
