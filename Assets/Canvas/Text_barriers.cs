using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Text_barriers : MonoBehaviour
{
    //internal Collider col;
    private float fd = 5.0f;
    public void OnGUI()
    {
        // fps = 1.0f / Time.deltaTime;
        GUILayout.Label("Вернитесь в зону: ");// + fd);
        
    }
}
