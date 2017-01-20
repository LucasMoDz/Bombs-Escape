using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeBar : MonoBehaviour
{
    public Image barTime;
    
	public void StartTimer()
    {
		StartCoroutine(DecreaseBarCO());
	}

    public IEnumerator DecreaseBarCO()
    {
        while (barTime.fillAmount > 0)
        {
            yield return new WaitForSeconds(1);
            barTime.fillAmount -= 0.0055555f;
        }


    }

    public void ResetTimer()
    {
        barTime.fillAmount = 1;
    }
}