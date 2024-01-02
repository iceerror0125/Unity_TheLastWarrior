using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonBattleState : EnemyBattleState
{
    Skeleton skeleton;
    public SkeletonBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        skeleton = (Skeleton)enemy;
        if (skeleton.isAttackImmediately)
        {
            attackCountdownTimer = -1;
        }
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.SetAttackImmediately(false);
    }

    public void AttackImmediately()
    {
        attackCountdownTimer = -1;
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.X))
        {
            stateMachine.ChangeState(skeleton.shieldState);
        }
    }
}
