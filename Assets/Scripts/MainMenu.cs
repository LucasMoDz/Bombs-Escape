using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject arena;
    public Image radialSlider;
    public float secondsToFade = 2;
    public float secondsToFill;
    private CanvasGroup mainMenuCanvasGroup;
    
	private void Awake()
    {
        arena.SetActive(false);
        mainMenuCanvasGroup.alpha = 1;
        mainMenuCanvasGroup = this.GetComponent<CanvasGroup>();
        Time.timeScale = 0;
	}
	
	public void FadeCanvasGroup()
    {
        StartCoroutine(FadeCanvasGroupOnMainMenuCO());
    }

    private IEnumerator FadeCanvasGroupOnMainMenuCO()
    {
        while(mainMenuCanvasGroup.alpha > 0)
        {
            mainMenuCanvasGroup.alpha -= (Time.deltaTime / secondsToFade);
            yield return null;
        }
    }

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