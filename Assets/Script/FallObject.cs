using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallObject : MonoBehaviour
{
    private Vector2 player;
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    void Update()
    {
        player = PlayerManager.instance.player.transform.position;
        if (transform.position.y - player.y > 0.5 && Vector2.Distance(transform.position, player) < 4)
        {
            rb.AddForce(Vector2.down * speed);
        }
        if (transform.position.y < -10)
            Destroy(gameObject);
    }

}
