using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chrosshair : MonoBehaviour
{
    public float currentSpeed;
    public float speedSpread;

    public Parts[] parts;
    public CharacterMovement characterMovement;

    float t;
    float curSpread;



    // Update is called once per frame
    void Update()
    {
        if(characterMovement.moveAmount > 0)
            currentSpeed = 20 * (5 + characterMovement.moveAmount);
        else
            currentSpeed = 20;
        CrosshairUpdate();
    }

    void CrosshairUpdate()
    {
        t = 0.005f * speedSpread;
        curSpread = Mathf.Lerp(curSpread, currentSpeed, t);

        for(int i = 0; i < parts.Length; i++){
            Parts p = parts[i];
            p.trans.anchoredPosition = p.pos * curSpread;
        }
    }

    [System.Serializable]
    public class Parts
    {
        public RectTransform trans;
        public Vector2 pos;
    }
}
