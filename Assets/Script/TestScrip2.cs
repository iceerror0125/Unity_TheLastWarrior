using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestScrip2 : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Stay");

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Exit");

    }

   
}
