using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValue : MonoBehaviour
{
    public Slider slider;
    private FloatSO scoreSO;

    void Start()
    {
        scoreSO.Value = slider.value;
    }

    void Update()
    {
        scoreSO.Value = slider.value;
    }
}
