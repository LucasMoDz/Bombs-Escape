using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public CanvasGroup mainMenuCanvasGroup;

    public GameObject arena;

    public float seconds = 2;
    
	private void Awake()
    {
        arena.SetActive(false);
        
        mainMenuCanvasGroup.alpha = 1;

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
            mainMenuCanvasGroup.alpha -= (Time.deltaTime / seconds);
            yield return null;
        }

        arena.SetActive(true);
    }
}