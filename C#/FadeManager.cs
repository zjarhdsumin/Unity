using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public SpriteRenderer white;
    public SpriteRenderer black;
    private Color color;
    private WaitForSeconds waitTime = new WaitForSeconds(0.01f);

    public void FadeOut(float speed = 0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FadeOutCoroutine(speed));
    }

    public void FadeIn(float speed = 0.02f)
    {
        StopAllCoroutines();
        StartCoroutine(FadeInCoroutine(speed));
    }

    IEnumerator FadeOutCoroutine(float _s)
    {
        color = black.color;

        while (color.a < 1f)
        {
            color.a += _s;
            black.color = color;
            yield return waitTime;
        }

    }

    IEnumerator FadeInCoroutine(float _s)
    {
        color = black.color;

        while (color.a > 0)
        {
            color.a -= _s;
            black.color = color;
            yield return waitTime;
        }

    }
}
