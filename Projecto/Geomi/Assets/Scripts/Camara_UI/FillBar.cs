using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{
    public Slider slider;
    public TMPro.TextMeshProUGUI displayText;
    public PlayerMovement a;

    private float currentValue = 0f;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            slider.value = currentValue;
            if(a.stage == 2) displayText.text = (slider.value).ToString("0") + "/8";
            else displayText.text = (slider.value).ToString("0") + "/12";
        }
    }

    void Start()
    {
        a = FindObjectOfType<PlayerMovement>();
        CurrentValue = a.chikitos;
    }

    // Update is called once per frame
    void Update()
    {
        if (a.stage == 2)
        {
           slider.maxValue = 8;
           CurrentValue = a.valeria;

        }
        else CurrentValue = a.chikitos;
    }
}
