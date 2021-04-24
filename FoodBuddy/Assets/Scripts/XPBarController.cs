using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBarController : MonoBehaviour
{
    public Slider slider;


    public void SetMaxXP(int value)
    {
        slider.maxValue = value;
    }

    public bool IsMax()
    {
        if (slider.value == slider.maxValue)
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

    public void SetXP(int value)
    {
        slider.value = value;
    }
}
