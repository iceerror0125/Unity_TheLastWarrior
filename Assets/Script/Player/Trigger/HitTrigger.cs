using System;
using UnityEngine;

public class HitTrigger
{
    public void ActiveTrigger(Buff3 _skill, Heal2 _heal)
    {
        var player = PlayerManager.instance.player;
        var colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            HitEnemy(_skill, _heal, player, collider);
            HitBrokenWall(collider);
        }

    }

    private void HitBrokenWall(Collider2D collider)
    {
        var brokenWall = collider.gameObject.GetComponent<BrokenWall>();
        if (brokenWall != null)
        {
            brokenWall.HitWall();
        }
    }

    private static void HitEnemy(Buff3 _skill, Heal2 _heal, Player player, Collider2D collider)
    {
        var enemy = collider.GetComponent<Enemy>();
        if (enemy != null && !enemy.IsDead)
        {
            //player.PerformNormalAttack(enemy);
            player.CauseDamage(enemy, isCrit: true);

            if (enemy.stat.Hp < 0)
            {
                enemy.stateMachine.ChangeState(enemy.deadState);
            }

            if (_skill != null && _skill.IsActivated)
            {
                _skill.Trigger();
            }

            if (_heal != null && _heal.IsUnlock)
            {
                _heal.HitEnemy();
                _heal.Activate();
            }
        }
    }
}
