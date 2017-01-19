using UnityEngine;
using System.Collections;

public class BombMovement : MonoBehaviour
{
    public GameObject[] nearbyObjects;
    private Bomb bomb;
    
    private float speed = 2;

    private void Awake()
    {
        bomb = GameObject.FindGameObjectWithTag("Bomb").GetComponent<Bomb>();
    }

    public void CheckAndStartMovement()
    {
        

        for (int i = 0; i < nearbyObjects.Length; i++)
        {
            if (nearbyObjects[i].transform.name == bomb.transformName)
            {
                //Debug.Log(nearbyObjects[i].name);
                StartCoroutine(MoveBombFromAToBCO(this.transform));
                Debug.Log("Bomb CAN move");
                return;
            }
        }

        Debug.Log("Bomb CAN'T move");
    }

    private IEnumerator MoveBombFromAToBCO(Transform _target)
    {
        float step;

        // Aggiorna il target attuale della bomba
        bomb.transformName = this.transform.name;

        while ((_target.position - bomb.gameObject.transform.position).magnitude > 0.005f)
        {
            Debug.Log("Moving");
            step = speed * Time.deltaTime;
            bomb.gameObject.transform.position = Vector3.MoveTowards(bomb.gameObject.transform.position, _target.position, step);
            yield return null;
        }

        bomb.gameObject.transform.position = _target.position;
    }
}