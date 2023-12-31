using UnityEngine;

public class HitEnemyTrigger
{
    public void ActiveTrigger(Buff3 _skill, Heal2 _heal)
    {
        var player = PlayerManager.instance.player;
        var colliders = Physics2D.OverlapCircleAll(player.AttackCheck.position, player.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var enemy = collider.GetComponent<Enemy>();
            if (enemy != null && !enemy.stat.IsDead)
            {
                player.Hit(enemy);

                if (_skill.IsActivated)
                {
                    _skill.Trigger();
                }

                if (_heal.IsUnlock)
                {
                    _heal.HitEnemy();
                    _heal.Activate();
                }
            }
        }

    }
}
