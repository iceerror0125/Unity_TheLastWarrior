using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FireWormBattleState : EnemyBattleState
{
    FireWorm fireWorm;
    public FireWormBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        fireWorm = (FireWorm)enemy;
        timer = fireWorm.AttackCountDown;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        MoveController();
        if (timer < 0)
        {
            stateMachine.ChangeState(fireWorm.attackState);
        }
        
    }

    private void MoveController()
    {
        if (Vector2.Distance(player.transform.position, fireWorm.transform.position) < fireWorm.DistanceStopMoving)
        {
            // move backward when player appproaches enemy
            fireWorm.ChangeVelocity(fireWorm.MoveSpeed * fireWorm.EntityDir * -1, fireWorm.rb.velocity.y);
        }
        if (Vector2.Distance(player.transform.position, fireWorm.transform.position) > fireWorm.ExitBattleDistance)
        {
            // to idle state when player is too far from fire worm
            exitBattleStateTimer = -1;
        }
    }
}
