using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeBattleState : BeeState
{
    public BeeBattleState(string _animName)
    {
        animName = _animName;
    }
    float exitBattleStateTimer;
    Player player;
    
    public override void Enter()
    {
        base.Enter();
        bee.SetIsDetectedPlayer(true);

        timer = bee.ToAttackStateTimer;
        exitBattleStateTimer = bee.ExitBattleStateTime;

        player = PlayerManager.instance.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        bee.TurnToPlayer();
        MoveController();
        TransitionStateCheck();
        ExitStateCheck();

        if (timer < 0 && bee.DetectPlayer())
        {
            stateMachine.ChangeState(bee.attackState);
        }
    }

    private void ExitStateCheck()
    {
        exitBattleStateTimer -= Time.deltaTime;
        if (exitBattleStateTimer < 0)
        {
            stateMachine.ChangeState(bee.idleState);
        }
    }

    private void MoveController()
    {
        if (bee.DetectPlayer())
        {
            bee.ZeroVelocity();
        }
        else
        {
            bee.ChangeVelocity(bee.MoveSpeed() * bee.EntityDir(), bee.rb.velocity.y);
        }
    }


    private void TransitionStateCheck()
    {
        if (exitBattleStateTimer < 0 || player.stat.IsDead)
        {
            stateMachine.ChangeState(bee.idleState);
        }
    }
}
