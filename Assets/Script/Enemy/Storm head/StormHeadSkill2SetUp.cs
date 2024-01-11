using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadSkill2SetUp : MonoBehaviour
{
    [SerializeField] private GameObject skill1;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dir;
    [SerializeField] private float jumpCounter;

    private float speed;
    private float timer;
    private bool isHit;

    Rigidbody2D rb;
    StormHead sh;

    public void Activate(StormHead sh)
    {
        this.sh = sh;
        Start();
        Update();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
            rb.velocity = new Vector2(speed * dir, rb.velocity.y);
    }
    public void DestroyOrZeroSpeed()
    {
        if (jumpCounter > 0)
        {
            jumpCounter--;
            speed = 0;
            timer = 0.5f;
            isHit = false;
        }
        else
        {
            Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + 0.8f);
            GameObject skill = Instantiate(skill1, spawnPos, Quaternion.identity);
            skill.GetComponent<StormHeadSkill1SetUp>().Activate(sh);

            Destroy(gameObject);
        }
    }
    public void CheckPlayerPostion()
    {
        if (transform.position.x > sh.player.transform.position.x) // right side of the player
        {
            dir = -1;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else // left side
        {
            dir = 1;
            transform.localScale = new Vector3(1, 1, 1);
        }
        speed = moveSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CauseDamage(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CauseDamage(collision);
    }
    private void CauseDamage(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            if (!isHit)
            {
                sh.CauseDamage(player);
                isHit = true;
            }
        }
    }
}
