using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BrokenWallSide
{
    Left, Right, Both
}
public class BrokenWall : MonoBehaviour
{
    [SerializeField] private GameObject hideWall;
    [SerializeField] private int hp = 3;
    [SerializeField] private BrokenWallSide side;
    public bool isAppearWall;

    public void HitWall()
    {
        LoseHP();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            
            LoseHP();
        }

    }

    private void LoseHP()
    {
        if (side != BrokenWallSide.Both)
        {
            BrokenWallSide playerSide = PlayerSide();
            if (playerSide != side)
            {
                return;
            }
        }
        

        hp--;
        if (hp <= 0)
        {
            Destroy(gameObject);
            if (hideWall == null)
                return;
            if (isAppearWall)
            {
                hideWall.SetActive(true);
            }
            else
            {
                hideWall.GetComponent<HideWall>().FadeWall();
            }
        }
    }

    private BrokenWallSide PlayerSide()
    {
        if (PlayerManager.instance.player.transform.position.x > transform.position.x)
        {
            return BrokenWallSide.Right;
        }
        return BrokenWallSide.Left;
    }
}
