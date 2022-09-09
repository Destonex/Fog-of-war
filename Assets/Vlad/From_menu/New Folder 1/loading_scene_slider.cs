using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loading_scene_slider : MonoBehaviour
{
    public int sceneID;
    public Slider loadingImg;
    //public Text progressText;

   void Start(){ 
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        while (!operation.isDone)
        {
            float progress = (operation.progress / 0.9f) * 100;
            loadingImg.value = progress;
            yield return null;
        }
    }

  /*  void Update()
    {
        if (slider.value == 100) {
        Text.SetActive(true);
        if (Input.GetKey(button)) {
        AsyncLoad();
        }
        }
    }*/

}


