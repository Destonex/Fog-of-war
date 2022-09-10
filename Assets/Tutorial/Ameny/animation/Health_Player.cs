using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health_Player : MonoBehaviour
{
    public int Health = 100;
    public Slider slider;
    public Text hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        slider.value = Health;
        hp.text = string.Format("{0:0}", Health);
        if(Health<=0)
            gameObject.SetActive(false);
    }
}
