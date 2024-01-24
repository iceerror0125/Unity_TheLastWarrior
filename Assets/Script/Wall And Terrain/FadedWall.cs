using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadedWall : MonoBehaviour
{
    private Tilemap tileMap;

    void Start()
    {
        tileMap = GetComponent<Tilemap>();
    }

    private void FadeColor()
    {
        StartCoroutine(FadeRoutine());
    }
    private IEnumerator FadeRoutine()
    {
        while (tileMap.color.a > 0.5f)
        {
            tileMap.color = new Color(1, 1, 1, tileMap.color.a - 0.05f);
            yield return null;
        }
        tileMap.color = new Color(1, 1, 1, 0.5f);
    }

    private void FillColor()
    {
        StartCoroutine(FillRoutine());

    }
    private IEnumerator FillRoutine()
    {
        while (tileMap.color.a < 1f)
        {
            tileMap.color = new Color(1, 1, 1, tileMap.color.a + 0.05f);
            yield return null;
        }
        tileMap.color = Color.white;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            FadeColor();
        }
    }
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            FadeColor();
        }

    }*/
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            FillColor();
        }
    }
}
