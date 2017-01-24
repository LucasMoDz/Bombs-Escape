using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    public GameObject fire;

    private GameObject bomb;
    private Vector3 bombStartPosition;

    private Win winCanvas;
    
    private void Awake()
    {
        bomb = GameObject.FindGameObjectWithTag("Bomb");
        winCanvas = FindObjectOfType<Win>();
        bombStartPosition = bomb.transform.position;
    }

	public void StartTimer()
    {
		StartCoroutine(DecreaseBarCO());
	}

    public IEnumerator DecreaseBarCO()
    {
        fire.SetActive(true);

        while (barTime.fillAmount > 0)
        {
            yield return new WaitForSeconds(1);
            barTime.fillAmount -= 0.01f;
        }

        StartCoroutine(RestartCO());
    }

    public void Restart()
    {
        StartCoroutine(RestartCO());
    }

    private IEnumerator RestartCO()
    {
        yield return new WaitForSeconds(2);
        barTime.fillAmount = 1;
        bomb.transform.position = bombStartPosition;
        bomb.GetComponent<Bomb>().transformName = "Target_Bomb (-1)";
        GameObject.Find("CanvasWinner").GetComponent<CanvasGroup>().alpha = 0;
        StartTimer();
    }
}