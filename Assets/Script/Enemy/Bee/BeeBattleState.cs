using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeBattleState : EnemyBattleState
{
   
    float exitBattleStateTimer;
    Player player;
    Bee bee;
    public BeeBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bee = (Bee)enemy;
        player = PlayerManager.instance.player;

        bee.SetIsDetectedPlayer(true);

        timer = bee.ToAttackStateTimer;
        exitBattleStateTimer = bee.ExitBattleStateTime;
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
            stateMachine.ChangeState(bee.AttackState);
        }
    }

    private void ExitStateCheck()
    {
        exitBattleStateTimer -= Time.deltaTime;
        if (exitBattleStateTimer < 0)
        {
            stateMachine.ChangeState(bee.IdleState);
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
            bee.ChangeVelocity(bee.MoveSpeed * bee.EntityDir, bee.rb.velocity.y);
        }
    }


    private void TransitionStateCheck()
    {
        if (exitBattleStateTimer < 0 || player.stat.IsDead)
        {
            stateMachine.ChangeState(bee.IdleState);
        }
    }
}
