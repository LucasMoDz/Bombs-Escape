using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PointerVR : MonoBehaviour
{
    public Image radialSlider;
    public float secondsToFill;

    public UnityEvent unityEvent;

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

        unityEvent.Invoke();
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