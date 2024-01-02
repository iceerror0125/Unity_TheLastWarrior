using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetIsAttack(true);
    }

    public override void Exit()
    {
        base.Exit();
        // Attack is equal false in cancel attack trigger
    }

    public override void Update()
    {
        base.Update();
        enemy.ZeroVelocity();
        if (!enemy.IsAttack)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
