using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWormDeadState : EnemyDeadState
{
    FireWorm fireWorm;
    public FireWormDeadState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        fireWorm = (FireWorm)enemy;
        timer = fireWorm.ExplodeCountdown;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0 )
        {
            stateMachine.ChangeState(fireWorm.explosionState);
        }
    }
}
