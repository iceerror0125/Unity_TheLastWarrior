using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasuTenguTrigger : EnemyTrigger
{
    KarasuTengu tengu;
    protected override void Start()
    {
        base.Start();
        tengu = (KarasuTengu)enemy;
    }
    public void Attack3Trigger()
    {
        tengu.DisableAlert();

        var colliders = Physics2D.OverlapCircleAll(enemy.AttackCheck.position, enemy.AttackCheckRadius);
        foreach (var collider in colliders)
        {
            var player = collider.GetComponent<Player>();
            if (player != null && !player.IsDead)
            {
                tengu.SetIsHitPlayer(true);
            }
        }
    }
    public void EnableAlert()
    {
        tengu.EnableAlert();
    }
}
