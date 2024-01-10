using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliteEnemyBattleState : EnemyBattleState
{
    public EliteEnemyBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        /*if (enemy.IsPlayerInAttackRange())
        {
            enemy.ChangeVelocity(enemy.MoveSpeed * 0.75f * enemy.EntityDir * -1, enemy.rb.velocity.y);
        }*/
        if (Vector2.Distance(enemy.transform.position, enemy.player.transform.position) < 2f)
        {
            enemy.ZeroVelocity();
        }
        else
        {
            float dir = enemy.IsOnTheRightOfPlayer() ? -1 : 1;
            enemy.ChangeVelocity(enemy.MoveSpeed * dir, enemy.rb.velocity.y);
        }

    }
}
