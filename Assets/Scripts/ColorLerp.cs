using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorLerp : MonoBehaviour
{
    private Text textColor;

    private IEnumerator Start()
    {
        textColor = this.GetComponent<Text>();
        Color lerpedColor;

        while (true)
        {
            lerpedColor = Color.Lerp(Color.yellow, Color.red, Mathf.PingPong(Time.time / 2, 1));
            textColor.color = lerpedColor;
            yield return null;
        }
    }
}