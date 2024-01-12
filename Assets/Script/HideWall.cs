using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWall : MonoBehaviour
{
    public float speed = 10f;
    private SpriteRenderer sr;
    private bool isActive;
    public void FadeWall()
    {
        isActive = true;
    }
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - speed * Time.deltaTime);
        if (sr.color.a < 0)
        {
            Destroy(gameObject);
        }
    }
}
