using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerTrigger
{
    public void ActiveTrigger(Enemy enemy)
    {
        var colliders = Physics2D.OverlapCircleAll(enemy.AttackCheck.position, enemy.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var player = collider.GetComponent<Player>();
            if (player != null && !player.IsDead)
            {
                //enemy.PerformNormalAttack(player);
                enemy.CauseDamage(player, enemy.stat.Damage * 2, isCrit: true);

            }
        }
    }
}
