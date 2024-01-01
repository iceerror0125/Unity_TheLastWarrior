using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float existTimer;

    private Vector2 target;
    void Start()
    {
        target = PlayerManager.instance.player.transform.position;
    }

    public void Activate()
    {
        Start();
        Update();
    }


    void Update()
    {
        existTimer -= Time.deltaTime;
        transform.position = Vector2.Lerp(transform.position, target, speed * Time.deltaTime);

        if (existTimer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            EnemyManager.instance.bee.PerformNormalAttack(collision.GetComponent<Player>());
        }
    }
}
