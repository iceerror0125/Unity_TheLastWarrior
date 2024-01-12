using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackScreen : MonoBehaviour
{
    public static BlackScreen instance;
    private FadeController fade;
    private Image img;
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

    }
    void Start()
    {
        img = GetComponent<Image>();
        fade = GetComponent<FadeController>();
    }

    public void FadeOut()
    {
        Start();
        fade.FadeOut();
    }
    public void FadeIn()
    {
        Start();
        fade.FadeIn();
    }
    public bool IsTransparent()
    {
        if (img.color.a <= 0) return true;
        return false;
    }
    public bool IsFill()
    {
        if (img.color.a >= 1) return true;
        return false;
    }
}
