using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayerTrigger
{
    public void ActiveTrigger(Enemy _enemy)
    {
        var colliders = Physics2D.OverlapCircleAll(_enemy.AttackCheck.position, _enemy.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var player = collider.GetComponent<Player>();
            if (player != null && !player.IsDead)
            {
                _enemy.PerformNormalAttack(player);
            }
        }
    }
}
