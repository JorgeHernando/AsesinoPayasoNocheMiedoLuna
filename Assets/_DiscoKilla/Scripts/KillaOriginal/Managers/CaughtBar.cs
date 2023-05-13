using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Caughtbar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI textMesh;

    public void SetMaxCatch(int value)
    {
        slider.maxValue = value;
        slider.value = value;
        textMesh.text = value.ToString();
    }
    public void SetCatch(int value)
    {
        slider.value -= value;
        textMesh.text = slider.value.ToString();
    }
}
