using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Settings : MonoBehaviour
{
    public GameObject video;
    public GameObject sound;


    void Start()
    {
        video.SetActive(true);
        sound.SetActive(false);
    }
    public void Video()
    {
        video.SetActive(true);
        sound.SetActive(false);
    }


    public void Sound() {
        video.SetActive(false);
        sound.SetActive(true);
    }


}