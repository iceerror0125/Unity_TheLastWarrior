using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common3BattleState : Common3State
{
    float exitBattleStateTimer;
    float distanceStopMoving;
    float moveBackwardSpeed;
    Player player;
    public Common3BattleState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        common3.SetIsDetectedPlayer(true);

        timer = common3.ToAttackStateTimer;
        exitBattleStateTimer = common3.ExitBattleStateTime;
        distanceStopMoving = common3.DistanceStopMoving;
        moveBackwardSpeed = common3.MoveBackwardSpeed;

        player = PlayerManager.instance.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        common3.TurnToPlayer();
        MoveController();
        TransitionStateCheck();
        ExitStateCheck();

        if (timer < 0 && common3.DetectPlayer()) 
        {
            stateMachine.ChangeState(common3.attackState);
        }
    }

    private void ExitStateCheck()
    {
        exitBattleStateTimer -= Time.deltaTime;
        if (exitBattleStateTimer < 0)
        {
            stateMachine.ChangeState(common3.idleState);
        }
    }

    private void MoveController()
    {
        if (common3.DetectPlayer())
        {
            common3.ZeroVelocity();
        }
        else
        {
            common3.ChangeVelocity(common3.MoveSpeed() * common3.EntityDir(), common3.rb.velocity.y);
        }
    }

   
    private void TransitionStateCheck()
    {
        if (exitBattleStateTimer < 0 || player.stat.IsDead)
        {
            stateMachine.ChangeState(common3.idleState);
        }
    }
}
