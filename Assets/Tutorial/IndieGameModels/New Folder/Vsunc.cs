using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vsunc : MonoBehaviour
{
    public KeyCode button;
    public int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKey(button)) {
         i++;
        }

            if (i == 0)
            {
                Application.targetFrameRate = 0;   
            }
            else if (i == 1)
            {
              Application.targetFrameRate = 60;   
            }
            else if (i == 2) 
            {
                Application.targetFrameRate = 30;
            }
             else if (i == 3)
            {
                i = 0; 
            }

    }
}
