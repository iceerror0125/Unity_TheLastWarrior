using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common2DeadState : EnemyDeadState
{
    public Common2DeadState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        ((Common2)enemy).SetIsInDeadState(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        ((Common2)enemy).ZeroVelocity();
    }
}
