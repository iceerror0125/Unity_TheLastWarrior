using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        enemy.ZeroVelocity(); // In case it can't access Update()
        enemy.SetIsInDeadState(true);
        enemy.rb.gravityScale = 4;
    }

    public override void Exit()
    {
        base.Exit();
        // enemy.SetIsInDeadState(false);
    }

    public override void Update()
    {
        base.Update();
        enemy.ZeroVelocity();
    }
}
