using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeBattleState : EnemyBattleState
{
   
    Bee bee;
    public BeeBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bee = (Bee)enemy;
        bee.SetIsDetectedPlayer(true);

        timer = bee.ToAttackStateTimer;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        MoveController();

        if (timer < 0 && bee.DetectPlayer())
        {
            stateMachine.ChangeState(bee.attackState);
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
}
