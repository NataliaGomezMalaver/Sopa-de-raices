using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarradeVegetales : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxVegetables(int vegetables)
    {
        slider.maxValue= vegetables;
        slider.value= vegetables;
    }

    public void Setvegetables(int vegetables)
    {
        slider.value= vegetables;
    }

}
