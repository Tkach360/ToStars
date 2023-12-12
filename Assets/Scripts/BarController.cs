using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BarController : MonoBehaviour
{
    [SerializeField] private Slider barSlider;

    public void SetMaxValue(int maxValue)
    {
        barSlider.maxValue = maxValue;
        barSlider.value = maxValue;
    }

    public int GetValue()
    {
        return (int)barSlider.value;
    }

    public void ChangeValue(int value)
    {
        if (value > barSlider.maxValue)
            barSlider.value = barSlider.maxValue;
        else if (value < barSlider.minValue)
            barSlider.value = barSlider.minValue;
        else
            barSlider.value = value;
    }
}
