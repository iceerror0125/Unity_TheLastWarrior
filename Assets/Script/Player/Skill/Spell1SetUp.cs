using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class Spell1Animation : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private float speed;
    private Vector2 limitLeft;
    private Vector2 limitRight;

    public void Activate()
    {
        limitLeft = PlayerManager.instance.player.transform.position + new Vector3(-3, 0);
        limitRight = PlayerManager.instance.player.transform.position + new Vector3(3, 0);
        Update();
    }
    private void SetUp()
    {
        left.position = Vector2.MoveTowards(left.position, limitLeft, speed * Time.deltaTime);
        right.position = Vector2.MoveTowards(right.position, limitRight, speed * Time.deltaTime);
        if (Vector2.Distance(left.position, limitLeft) < 0.001f)
        {
            FadedSkill();
        }
    }

    private void Update()
    {
        SetUp();
    }

    private void FadedSkill()
    {
        SpriteRenderer srLeft = left.gameObject.GetComponent<SpriteRenderer>();
        SpriteRenderer srRight = right.gameObject.GetComponent<SpriteRenderer>();

        srLeft.color = new Color(srLeft.color.r, srLeft.color.g, srLeft.color.b, srLeft.color.a - speed/5 * Time.deltaTime);
        srRight.color = new Color(srRight.color.r, srRight.color.g, srRight.color.b, srRight.color.a - speed/5 * Time.deltaTime);

        if (srLeft.color.a < 0)
        {
            Destroy(gameObject);   
        }
    }

}
