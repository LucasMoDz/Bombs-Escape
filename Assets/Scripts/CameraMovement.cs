using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;

// CAMBIARE POINTER EXIT SULLA CAMERS CON UN BOOLEANO
public class CameraMovement : MonoBehaviour
{
    public Image radialSlider;
    public float secondsToFill;
    
    private float speed = 2;
    bool isMoving;
    
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

        StartCoroutine(MoveCamera(this.transform));
    }

    private IEnumerator DecreaseFillAmountCO()
    {
        while (radialSlider.fillAmount > 0)
        {
            radialSlider.fillAmount -= (Time.deltaTime * 2);
            yield return null;
        }
    }

    private IEnumerator MoveCamera(Transform _target)
    {
        float step;
        isMoving = true;

        while ((_target.position - Camera.main.transform.position).magnitude > 0.005f)
        {
            step = speed * Time.deltaTime;
            Camera.main.transform.position = Vector3.MoveTowards(Camera.main.transform.position, _target.position, step);
            yield return null;
        }

        Camera.main.transform.position = _target.position;
        isMoving = false;
    }
}