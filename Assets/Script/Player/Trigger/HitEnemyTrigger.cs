using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemyTrigger
{
    public void ActiveTrigger(Buff3 _skill)
    {
        var player = PlayerManager.instance.player;
        var colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null && !enemy.stat.IsDead)
            {
                player.Hit(enemy);
                enemy.stat.TakeDamage(player.PlayerStat.Damage);

                if (_skill.IsActivated)
                {
                    _skill.Trigger();
                }
            }
        }

    }
}
