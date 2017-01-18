using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

// Gli passo un gameobject e comparo il nome! cambiare skybox quando vinci
public class LoadingTarget : MonoBehaviour
{
    public Image radialSlider;
    public float secondsToFill;

    public byte numberOfTarget;

    internal Action<byte> targetEvent;

    public void StartTimer()
    {
        StopAllCoroutines();
        StartCoroutine(IncreaseFillAmountCO());
    }

    public void StopTimer()
    {
        StopAllCoroutines();
        StartCoroutine(DecreaseFillAmountCO());
    }
    
    private IEnumerator IncreaseFillAmountCO()
    {
        while (radialSlider.fillAmount < 1)
        {
            radialSlider.fillAmount += (Time.deltaTime / secondsToFill);
            yield return null;
        }
        
        targetEvent(numberOfTarget);
    }

    private IEnumerator DecreaseFillAmountCO()
    {
        while (radialSlider.fillAmount > 0)
        {
            radialSlider.fillAmount -= (Time.deltaTime * 2);
            yield return null;
        }
    }
}