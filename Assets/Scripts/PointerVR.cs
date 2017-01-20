using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;

public class PointerVR : MonoBehaviour
{
    private IEnumerator increaseFillAmount, decreaseFillAmount;

    public Image radialSlider;
    public float secondsToFill;

    public UnityEvent unityEvent;

    public void StartTimer()
    {
        SetIEnumerator();
        StopCoroutine(decreaseFillAmount);
        StartCoroutine(increaseFillAmount);
    }

    public void StopTimer()
    {
        StopCoroutine(increaseFillAmount);
        StartCoroutine(decreaseFillAmount);
    }
    
    private void SetIEnumerator()
    {
        increaseFillAmount = IncreaseFillAmountCO();
        decreaseFillAmount = DecreaseFillAmountCO();
    }

    private IEnumerator IncreaseFillAmountCO()
    {
        while (radialSlider.fillAmount < 1)
        {
            Debug.Log("Filling");
            radialSlider.fillAmount += (Time.deltaTime / secondsToFill);
            yield return null;
        }

        unityEvent.Invoke();
        StartCoroutine(DecreaseFillAmountCO());
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