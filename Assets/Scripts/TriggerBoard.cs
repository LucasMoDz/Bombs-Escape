using UnityEngine;
using System.Collections;

public class TriggerBoard : MonoBehaviour
{
    private Vector3 normalBoardPosition;
    private Vector3 pressedBoardPosition;

    private GameObject bomb;

    public float secondsCO = 0;

    private void Awake()
    {
        normalBoardPosition = this.GetComponent<Transform>().position;
        pressedBoardPosition = normalBoardPosition - new Vector3(0, 0.09348f, 0);

        bomb = GameObject.FindGameObjectWithTag("Bomb");
    }

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Bomb"))
        {
            Debug.Log("Colliso con la pedana");
            StartCoroutine(PressureMovementCO());
        }
    }

    private void OnTriggerExit(Collider _other)
    {
        StartCoroutine(ResetBoardPositionCO());
    }

    private IEnumerator PressureMovementCO()
    {
        while (secondsCO < 1)
        {
            secondsCO += (Time.deltaTime * 2);
            this.transform.position = Vector3.Lerp(normalBoardPosition, pressedBoardPosition, secondsCO);
            yield return null;
        }

        this.transform.position = pressedBoardPosition;
    }

    private IEnumerator ResetBoardPositionCO()
    {
        while (secondsCO > 0)
        {
            secondsCO -= (Time.deltaTime * 2);
            this.transform.position = Vector3.Lerp(normalBoardPosition, pressedBoardPosition, secondsCO);
            yield return null;
        }

        this.transform.position = normalBoardPosition;
    }
}