using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Task : MonoBehaviour
{
   /* [Header("��� NPC")]
    public bool EndDialog;
    public bool NPC;

    public For_NPC Code_NPC;
    public For_building Code_building;
    public stop_menu_in_game stpmen;

    [Header("��� ������ ������� ��������")]
    public GameObject Object;
    public GameObject Checkmark;

    public bool EndTrigger;

    void Start()
    {


        Checkmark.SetActive(false);

    }
    void Update()
    {
        if (EndDialog == true)
        {
            //Time.timeScale = 1;
            Code_NPC.Dialog1.SetActive(false);
            Code_NPC.Press.SetActive(false);
        }
    }
    void OnTriggerEnter(Collider col)
    {
        if (NPC == true) {
            Code_NPC.Press.SetActive(true);
            if (col.tag == "Player")
            {

                //Time.timeScale = 0;
                Code_NPC.Dialog1.SetActive(true);
                Checkmark.SetActive(true);
                Code_building.Toggle.SetActive(true);
            }
        }
        else{
            if (EndTrigger == false)
            {
                if (col.tag == "Player")
                {
                    Debug.Log("����� ����� � ������");
                    Checkmark.SetActive(true);
                    Code_building.Toggle.SetActive(true);
                    // Checkmark.GetComponent<GameObject> ().isOn(true);
                }
            }
            else {
                Checkmark.SetActive(true);
                
                Time.timeScale = 0.0f;
                Code_NPC.Win.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                stpmen.Camera.SetActive(true);
                stpmen.Player.SetActive(false);
            }
        }
    }*/
}
