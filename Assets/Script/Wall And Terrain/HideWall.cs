using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(OneTimeAppear))]
public class HideWall : MonoBehaviour
{
    public float speed = 10f;
    //private SpriteRenderer tm;
    private Tilemap tm;
    private bool isActive;
    public void FadeWall()
    {
        isActive = true;
    }
    void Start()
    {
        //tm = GetComponent<SpriteRenderer>();
        tm = GetComponent<Tilemap>();
    }

    void Update()
    {
        if (!isActive)
        {
            return;
        }
        /*tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, tm.color.a - speed * Time.deltaTime);
        if (tm.color.a < 0)
        {
            Destroy(gameObject);
        }*/

        tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, tm.color.a - speed * Time.deltaTime);
        if (tm.color.a < 0)
        {
            OneTimeAppear ota = GetComponent<OneTimeAppear>();
            if (ota != null)
            {
                ota.DestroyOTA();
            }

            Destroy(gameObject);
        }
    }
}
