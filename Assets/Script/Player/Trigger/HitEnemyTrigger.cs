using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyTrigger
{
    public void ActiveTrigger()
    {
        var player = PlayerManager.instance.player;
        var colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                player.CauseDamage(enemy);
            }
        }

    }
}
