using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FlyingEyeBattleState : EnemyBattleState
{
    private FlyingEye flyingEye;
    public FlyingEyeBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        flyingEye = (FlyingEye)enemy;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (flyingEye.isApproach)
        {
            flyingEye.transform.position = Vector2.MoveTowards(
             flyingEye.transform.position,
             flyingEye.OriginalPosition, 
             flyingEye.MoveSpeed * Time.deltaTime);
        }
        else
        {
            if (Vector2.Distance(player.transform.position, flyingEye.transform.position) < flyingEye.DetectPlayerDistance)
            {
                // move backward when player appproaches enemy
                flyingEye.ChangeVelocity(flyingEye.MoveSpeed * flyingEye.EntityDir * -1, flyingEye.rb.velocity.y);
            }
        }
    }
}
