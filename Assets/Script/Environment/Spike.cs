using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private float countdown = 1;
    private float timer;
    private void Update()
    {
        timer -= Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && timer < 0)
        {
            player.TakeDamage(10);
            player.ChangeVelocity(4 * player.EntityDir * -1, 4);
            player.stateMachine.ChangeState(player.hurtState);
            timer = countdown;
        }
    }
    
}
