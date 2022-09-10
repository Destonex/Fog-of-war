using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.AI;
using UnityEngine.Rendering.PostProcessing;
using System.Text.RegularExpressions;

public class Button_Status : MonoBehaviour
{
    public Button_Canvas button_canvas;
    public GameObject toggle_fps;
    public GameObject toggle_VSync;
    public GameObject toggle_ProcessVolume;
    public GameObject toggle_Audio;
    public GameObject toggle_Weapon;
    public GameObject toggle_Coordinate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(button_canvas.fpss.activeSelf == false)
            toggle_fps.SetActive(false);
        else
            toggle_fps.SetActive(true);


        if (button_canvas.vsync == false){
            toggle_VSync.SetActive(false);
        }   
        else{
            toggle_VSync.SetActive(true);
        }


         if(button_canvas.postProcessVolume.isGlobal == true)
            toggle_ProcessVolume.SetActive(false);
        else
            toggle_ProcessVolume.SetActive(true);


        if(button_canvas.cd.GetComponent<AudioListener>().enabled == false)
            toggle_Audio.SetActive(true);
        else
            toggle_Audio.SetActive(false);

        
        if(button_canvas.weaponScript.enabled == true)
            toggle_Weapon.SetActive(false);
        else
            toggle_Weapon.SetActive(true);


        if(button_canvas.coordinates.activeSelf == true){
            toggle_Coordinate.SetActive(true);
        }
        else{
            toggle_Coordinate.SetActive(false);
            
        }
    }
}
