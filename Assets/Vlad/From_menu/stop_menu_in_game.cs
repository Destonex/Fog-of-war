using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class stop_menu_in_game : MonoBehaviour
{
public KeyCode button;
public GameObject Stop_menu;
public GameObject Restart_menu;
public GameObject Camera;
public Slider slider;
public GameObject Player;

  void Start()
    {
     Camera.SetActive(false);
     Player.SetActive(true);  
    }

public void Update() {
 if (Input.GetKey(button)) {
  Time.timeScale = 0.0f;
  Stop_menu.SetActive(true);
  Cursor.visible = true;
  Cursor.lockState = CursorLockMode.None;
  Camera.SetActive(true);
  Player.SetActive(false);
 }
else if (slider.value == 0){
  Time.timeScale = 0.0f;
  Restart_menu.SetActive(true);
  Cursor.visible = true;
  Cursor.lockState = CursorLockMode.None;
  Camera.SetActive(true);
  Player.SetActive(false);
    }
}
public void Exit(){
        SceneManager.LoadScene("Menu 1");
    }

public void Resume(){
 Time.timeScale = 1.0f;
 Stop_menu.SetActive(false);  
 Camera.SetActive(false);
 Player.SetActive(true);
 }
 
public void Restart(){
SceneManager.LoadScene(SceneManager.GetActiveScene().name);
 }
}