using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonShieldState : EnemyState
{
    Skeleton skeleton;

    public SkeletonShieldState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        skeleton = (Skeleton)enemy;
        timer = skeleton.UseShieldDuration;
        skeleton.SetIsShield(true);
    }

    public override void Exit()
    {
        base.Exit();
        skeleton.SetIsShield(false);
        skeleton.SetAttackImmediately(true);
    }

    public override void Update()
    {
        base.Update();
        float dir = skeleton.IsOnTheRightOfPlayer() ? 1 : -1;
        if (dir == skeleton.EntityDir * -1)
        {
            skeleton.isImmortal = true ;
        }
        else
        {
            skeleton.isImmortal = false;
        }

        if (timer < 0)
        {
            stateMachine.ChangeState(skeleton.battleState);
        }
    }
}
