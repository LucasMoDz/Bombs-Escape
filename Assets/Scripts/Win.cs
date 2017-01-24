using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour
{
    private TimeBar timeBar;
    public GameObject fire;

    private void Awake()
    {
        timeBar = FindObjectOfType<TimeBar>();
    }

    public void Winner(CanvasGroup _winImage)
    {
        StartCoroutine(WinnerCO(_winImage));
    }

    private IEnumerator WinnerCO(CanvasGroup _winCanvasGroup)
    {
        yield return new WaitForSeconds(1.5f);
        fire.SetActive(false);

        float alpha = 0;

        while (_winCanvasGroup.alpha < 1)
        {
            alpha += Time.deltaTime / 2;
            _winCanvasGroup.alpha = alpha;
            yield return null;
        }

        yield return new WaitForSeconds(3);

        _winCanvasGroup.alpha = 1;

        timeBar.Restart();
    }
}