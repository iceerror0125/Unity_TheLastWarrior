using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    public EnemyMoveState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = enemy.MoveDuration;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.ChangeVelocity(enemy.MoveSpeed * enemy.EntityDir, enemy.rb.velocity.y);

        if (timer < 0 || enemy.IsWall || !enemy.CheckGroundAhead())
        {
            enemy.idleState.SetHasFlip(true);
            stateMachine.ChangeState(enemy.idleState);
        }
    }
}
