using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup mainMenuCanvasGroup;
    private TimeBar timeBar;
    public GameObject arena;

    public float seconds = 2;
    
	private void Awake()
    {
        arena.SetActive(false);
        mainMenuCanvasGroup.alpha = 1;
        timeBar = FindObjectOfType<TimeBar>();
        timeBar.transform.parent.gameObject.SetActive(false);
        
	}
	
	public void FadeCanvasGroup()
    {
        StartCoroutine(FadeCanvasGroupOnMainMenuCO());
    }

    private IEnumerator FadeCanvasGroupOnMainMenuCO()
    {
        FindObjectOfType<PointerVR>().StopTimer();

        while(mainMenuCanvasGroup.alpha > 0)
        {
            mainMenuCanvasGroup.alpha -= (Time.deltaTime / seconds);
            yield return null;
        }

        mainMenuCanvasGroup.gameObject.SetActive(false);
        arena.SetActive(true);
        
        timeBar.transform.parent.gameObject.SetActive(true);
        timeBar.StartTimer();
    }
}