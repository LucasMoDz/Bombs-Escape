using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    private CameraMovement[] cameras;
    private Transform cameraTransform;

    private float speed = 2;

    private bool isMoving;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
        cameras = FindObjectsOfType<CameraMovement>();
    }
    
    public void MoveCamera()
    {
        StartCoroutine(MoveCameraCO());
    }

    private IEnumerator MoveCameraCO()
    {
        Transform targetTransform = this.transform;
        float step;
        isMoving = true;
        Invoke("SetActiveAllCameras", 1.0f);

        while ((targetTransform.position - cameraTransform.position).magnitude > 0.005f)
        {
            step = speed * Time.deltaTime;
            cameraTransform.position = Vector3.MoveTowards(cameraTransform.position, targetTransform.position, step);
            yield return null;
        }

        cameraTransform.position = targetTransform.position;
        targetTransform.gameObject.SetActive(false);
        isMoving = false;
    }

    private void SetActiveAllCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
            cameras[i].gameObject.SetActive(true);
    }
}