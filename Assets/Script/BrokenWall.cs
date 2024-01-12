using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenWall : MonoBehaviour
{
    [SerializeField] private GameObject hideWall;
    private int hp = 3;

    public void HitWall()
    {
        hp--;
        if (hp <= 0 )
        {
            Destroy(gameObject);
            hideWall.GetComponent<HideWall>().FadeWall();
        }
    }
}
