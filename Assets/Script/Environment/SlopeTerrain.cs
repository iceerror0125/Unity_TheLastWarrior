using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeTerrain : MonoBehaviour
{
    float storeSpeed;


 /*   private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            storeSpeed = player.rb.gravityScale;
            player.rb.gravityScale = 50;
        }
    }*/
/*
    private void OnCollisionStay2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            storeSpeed = player.rb.gravityScale;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            player.rb.gravityScale = storeSpeed;
        }
    }*/
}
