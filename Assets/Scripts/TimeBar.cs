using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    
	public void Start()
    {
		StartCoroutine(DecreaseBar());
	}

    public IEnumerator DecreaseBar()
    {
        while (barTime.fillAmount > 0)
        {
            yield return new WaitForSeconds(1);
            barTime.fillAmount -= 0.0167f;
        }
    }
}