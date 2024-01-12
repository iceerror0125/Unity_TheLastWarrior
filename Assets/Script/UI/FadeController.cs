using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    private Image img;

    public void FadeIn()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeInCoroutine());
    }

    public void FadeOut()
    {
        img = GetComponent<Image>();
        StartCoroutine(FadeOutCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        for (float i = 0; i <= 1; i += Time.deltaTime * 1.5f)
        {
            img.color = new Color(0, 0, 0, i);
            yield return null;
        }
        img.color = new Color(0, 0, 0, 1);
    }
    private IEnumerator FadeOutCoroutine()
    {

        for (float i = 1; i >= 0; i -= Time.deltaTime * 1.5f)
        {
            img.color = new Color(0, 0, 0, i);

            yield return null;
        }
        img.color = new Color(0, 0, 0, 0);

    }
}
