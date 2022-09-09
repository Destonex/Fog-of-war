using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Graphics : MonoBehaviour
{
    public Dropdown dropDown;
    public Dropdown dropdown;
    public Toggle toggle;
    Resolution[] res;

    void Start()
    {
        Screen.fullScreen = true;
        toggle.isOn = false;


        //Graphics
        dropDown.ClearOptions();
       dropDown.AddOptions(QualitySettings.names.ToList());
        // dropDown.value = QualitySettings.GetQualityLevel(); //Графика как в Unity
        // dropDown.value = 2;//Графика medium

        //Resolution
        Resolution[] resolution = Screen.resolutions;
        res = resolution.Distinct().ToArray();
        string[] strRes = new string[res.Length];

        for (int i = 0; i < res.Length; i++)
        {
            // strRes[i] = res[i].width.ToString() + "x" + res[i].height.ToString();//отображение без Ghz
             strRes[i] = res[i].ToString();
        }
        dropdown.ClearOptions();
        dropdown.AddOptions(strRes.ToList());
        
        if (PlayerPrefs.HasKey("Quality") || PlayerPrefs.HasKey("Resolution") || PlayerPrefs.HasKey("FullScreen"))
        {
            dropDown.value = PlayerPrefs.GetInt("Quality");
            dropdown.value = PlayerPrefs.GetInt("Resolution");

            QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("Quality"));
            Screen.SetResolution(res[PlayerPrefs.GetInt("Resolution")].width, res[PlayerPrefs.GetInt("Resolution")].height, Screen.fullScreen);
            if (PlayerPrefs.GetInt("FullScreen") == 0)
            {
                Screen.fullScreen = false;
                toggle.isOn = !Screen.fullScreen;
            }
            else
            {
                Screen.fullScreen = true;
                toggle.isOn = !Screen.fullScreen;
            }
        }
        else
        {
            dropDown.value = QualitySettings.GetQualityLevel();
           Screen.SetResolution(res[res.Length - 1].width, res[res.Length - 1].height, Screen.fullScreen);
            dropdown.value = res.Length - 1;

            Screen.fullScreen = true;
            toggle.isOn = !Screen.fullScreen;
        }
    }

    public void SetQuality(){
        QualitySettings.SetQualityLevel(dropDown.value);
        PlayerPrefs.SetInt("Quality", dropDown.value);
    }

    public void SetRes()
    {
        Screen.SetResolution(res[dropdown.value].width, res[dropdown.value].height, Screen.fullScreen);
        PlayerPrefs.SetInt("Resolution", dropdown.value);
    }
 
    public void ScreenMode()
    {
        Screen.fullScreen = !toggle.isOn;
        if (Screen.fullScreen)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
    }
}