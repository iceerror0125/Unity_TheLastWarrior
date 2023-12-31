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
        if (enemy.MoveRange.x == 0)
        {
            enemy.ChangeVelocity(enemy.MoveSpeed * enemy.EntityDir, enemy.rb.velocity.y);

        }
        else
        {
            MoveOnAir();
        }
        if (timer < 0 || enemy.IsWall)
        {
            enemy.IdleState.SetHasFlip(true);
            stateMachine.ChangeState(enemy.IdleState);
        }
    }

    protected void MoveOnAir()
    {
        Vector2 moveVector = CalculateMoveVector();
        enemy.ChangeVelocity(enemy.MoveSpeed * moveVector.x, moveVector.y);
    }
    private Vector2 CalculateMoveVector()
    {
        float x = Random.Range(0, enemy.MoveRange.x);
        if (enemy.EntityDir < 0)
        {
            x *= -1;
        }

        float y = Random.Range(-enemy.MoveRange.y, enemy.MoveRange.y);
        return new Vector2(x, y);
    }
}
