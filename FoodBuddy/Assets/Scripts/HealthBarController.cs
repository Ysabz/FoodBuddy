using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image filled;


    public void SetMaxHealth(int value)
    {
        slider.maxValue = value;
    }

    public bool IsMax()
    {
        if(slider.value == slider.maxValue)
        {
            return true;
        }
        return false;
    }

    public bool IsMin()
    {
        if (slider.value == 0)
        {
            return true;
        }
        return false;
    }
    public void SetHealth(int value)
    {
        slider.value = value;
        filled.color = gradient.Evaluate(slider.normalizedValue);
    }
}
