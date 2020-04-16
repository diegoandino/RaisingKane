using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Meter : MonoBehaviour
{
	public Slider slider;

	public void setMaxValue(int value)
	{
		slider.maxValue = value;
		slider.value = value;
	}

	public void setValue(int value)
    {
		slider.value = value;
    }

    public int getValue()
    {
        return (int)slider.value;
    }
}
