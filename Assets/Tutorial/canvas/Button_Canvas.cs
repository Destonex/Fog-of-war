using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;
using System.Text.RegularExpressions;

public class Button_Canvas : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public GameObject fpss;
    public GameObject fps;
    public GameObject camera;

    public GameObject fon;
    public GameObject cd;


    public WeaponManager weaponScript;
    public GameObject weapon;
    //public GameObject canvas;

    public GameObject coordinates;

    public bool vsync = false;
    bool audio = false;
    public GameObject[] MRSV;
    private int i=0;
    private bool t = false;
    bool canvas = true;

    void Start()
    {
        fon.SetActive(false);
        //camera.SetActive(false);
        fpss.SetActive(false);
        fps.SetActive(true);
        camera.SetActive(false);
        foreach(var i in MRSV)
            i.SetActive(false);
    }

    public void FPS_Count(){
        if(fpss.activeSelf == false)
            fpss.SetActive(true);  
        else
            fpss.SetActive(false);    
    }
    public void VSync(){
         if (vsync == false){
            Application.targetFrameRate = 30;
            vsync = true;
        }   
        else{
            Application.targetFrameRate = 0;
            vsync = false; 
        }
         /*   if (i == 0)
            {
                Application.targetFrameRate = 60;   
                print(i);
                i++;
            }
            else if (i == 1)
            {
              Application.targetFrameRate = 30; 
              print(i);
              i++;  
            }
            else if (i == 2) 
            {
                Application.targetFrameRate = 0;
                print(i);
                i++;
            }
             else if (i == 3)
            {
                i = 0; 
            }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("r")){
    if(coordinates.activeSelf == true){
            coordinates.SetActive(false);
        }
        else{
            coordinates.SetActive(true);
            
        }
}


        if (Input.GetKeyDown("`") && canvas == true) {
            fon.SetActive(true);
            Time.timeScale = 0;
            t=true;
            fps.SetActive(false);
            camera.SetActive(true);
            foreach(var i in MRSV)
                i.SetActive(true);
            canvas = false;
            //fps.SetActive(false);
            //post_process.SetActive(true);
        }
        else if(Input.GetKeyDown("`") && canvas == false){
            fon.SetActive(false);
                    Time.timeScale = 1;
                t=false;
                fps.SetActive(true);
                camera.SetActive(false);
            foreach(var i in MRSV)
                i.SetActive(false);
            canvas = true;
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
        if(postProcessVolume.isGlobal == true)
            postProcessVolume.isGlobal = false;
        else
            postProcessVolume.isGlobal = true;

    }
 
    public void OnPreRender() {
        GL.wireframe = true;
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Audio(){
        if(cd.GetComponent<AudioListener>().enabled == true)
        {
            cd.GetComponent<AudioListener>().enabled = false;
            audio = true;
        }
        else
        {
            cd.GetComponent<AudioListener>().enabled = true;
            audio = false;
        }
    }

    public void Weapon(){
        if(weaponScript.enabled == true){
            weaponScript.enabled = false;
            weapon.SetActive(false);
        }
        else{
            weaponScript.enabled = true;
            weapon.SetActive(true);
        }
    }

    public void Coordinate(){
        if(coordinates.activeSelf == true){
            coordinates.SetActive(false);
        }
        else{
            coordinates.SetActive(true);
            
        }
    }
}




