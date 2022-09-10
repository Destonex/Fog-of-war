using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;

public class Canvas : MonoBehaviour
{
   // public FirstPersonCharacter FirstPersonCharacter; 
     
    public GameObject canvas;
    public PostProcessVolume postProcessVolume;
    public PostProcessLayer postProcessLayer;
    public GameObject fps;
    public GameObject camera;
    public KeyCode keyCode;
    

    //public GameObject canvas;
    public KeyCode keyCode1;
    public GameObject[] MRSV;

    public GameObject[] button_main;

    public GameObject[] button_render;

    public GameObject[] button_script;

    public GameObject[] button_visability;

    public LinkedList<GameObject> r = new LinkedList<GameObject>();

    private bool t;
    //public List buttons; 
    // Start is called before the first frame update
    void Start()
    {
        //camera.SetActive(false);
        //fps.SetActive(true);
        fps.SetActive(true);
        camera.SetActive(false);
        canvas.SetActive(false);
        t = false;
        foreach(var i in MRSV)
            i.SetActive(false);
        foreach (var i in button_main)
            i.SetActive(false);
        foreach (var i in button_render)
            i.SetActive(false); 
        foreach (var i in button_script)
            i.SetActive(false);
        foreach (var i in button_visability)
            i.SetActive(false);
    }

    // Update is called once per frame


    void Update(){
        if (Input.GetKeyDown(keyCode)) {
            canvas.SetActive(true);
            Time.timeScale = 0;
            t=true;
            fps.SetActive(false);
            camera.SetActive(true);
            foreach(var i in MRSV)
                i.SetActive(true);
                
            //fps.SetActive(false);
  //post_process.SetActive(true);
        }
        else if(Input.GetKeyDown(keyCode1)){
                canvas.SetActive(false);
                Time.timeScale = 1;
                t=false;
                fps.SetActive(true);
                camera.SetActive(false);
            foreach(var i in MRSV)
                i.SetActive(false);
            foreach (var i in button_main)
            i.SetActive(false);
            foreach (var i in button_render)
            i.SetActive(false); 
            foreach (var i in button_script)
            i.SetActive(false);
            foreach (var i in button_visability)
            i.SetActive(false);
            }
        if(t==true){
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
        }
        else{
                            Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
        }
 // Cursor.lockState = CursorLockMode.None;
        
    }


    public void postProcessVolume_active()
    {
        //postProcessVolume.GetComponent<PostProcessVolume>();
        postProcessVolume.isGlobal = false;
        //t.SetActive(false);
        //ppv.SetActive(false);
    }

    public void Main(){

        foreach(var i in button_main)
            i.SetActive(true);

                   foreach(var i in button_render)
            i.SetActive(false); 

                    foreach(var i in button_script)
            i.SetActive(false);

                    foreach(var i in button_visability)
            i.SetActive(false);
    }

        public void Render(){

        foreach(var i in button_render)
            i.SetActive(true);

                foreach(var i in button_main)
            i.SetActive(false);

                                foreach(var i in button_visability)
            i.SetActive(false);
    }

        public void Script(){

        foreach(var i in button_script)
            i.SetActive(true);
    }

        public void Visability(){

        foreach(var i in button_visability)
            i.SetActive(true);

                    foreach(var i in button_main)
            i.SetActive(false);

                   foreach(var i in button_render)
            i.SetActive(false); 


    }
}