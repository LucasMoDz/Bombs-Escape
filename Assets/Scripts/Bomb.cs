using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public byte currentBombTarget;
    private float speed = 2;

    public bool isMoving;

    private LoadingTarget[] targetsLoading;
    
    private void Awake()
    {
        targetsLoading = FindObjectsOfType<LoadingTarget>();

        foreach (var target in targetsLoading)
            target.targetEvent = CheckMovement;
    }
    
    private IEnumerator MoveBombFromAToBCO(Transform _target)
    {
        float step;
        isMoving = true;

        while ((_target.position - this.transform.position).magnitude > 0.005f)
        {
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
            yield return null;
        }

        this.transform.position = _target.position;
        isMoving = false;
    }

    private void CheckMovement(byte _numberOfTarget)
    {
        if ((currentBombTarget == _numberOfTarget - 1) || (currentBombTarget == _numberOfTarget + 1))
        {
            Debug.Log("Bomb position: " + currentBombTarget + " - Bomb target: " + _numberOfTarget + "\n" + "Bomb CAN move!");

            currentBombTarget = _numberOfTarget;
            FindTransformAndStartMove(_numberOfTarget);
        }
        else
            Debug.Log("Bomb CAN'T move!\n");
    }

    private void FindTransformAndStartMove(byte _numberOfTarget)
    {
        foreach (var target in targetsLoading)
        {
            if (target.numberOfTarget == _numberOfTarget)
            {
                StartCoroutine(MoveBombFromAToBCO(target.GetComponent<Transform>()));
                break;
            }
        }
    }
}