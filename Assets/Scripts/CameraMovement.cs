using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public Image radialSlider;
    public float secondsToFill;

    private CameraMovement[] cameras;

    private IEnumerator increaseFillAmount, decreaseFillAmount;
    private Transform cameraTransform;
    private float speed = 2;
    private bool isMoving;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        cameras = FindObjectsOfType<CameraMovement>();
    }
    
    public void StartTimer()
    {
        if (!isMoving)
        {
            increaseFillAmount = IncreaseFillAmountCO();
            decreaseFillAmount = DecreaseFillAmountCO();

            StopCoroutine(decreaseFillAmount);
            StartCoroutine(increaseFillAmount);
        }
    }

    public void StopTimer()
    {
        StopCoroutine(increaseFillAmount);
        StartCoroutine(decreaseFillAmount);
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
        Invoke("SetActiveAllCameras", 1.0f);

        while ((_target.position - cameraTransform.position).magnitude > 0.005f)
        {
            step = speed * Time.deltaTime;
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, _target.position, step);
            yield return null;
        }

        cameraTransform.position = _target.position;
        _target.gameObject.SetActive(false);
        isMoving = false;
    }

    private void SetActiveAllCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].gameObject.SetActive(true);
    }
}