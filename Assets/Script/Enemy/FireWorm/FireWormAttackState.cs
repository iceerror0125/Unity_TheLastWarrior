using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class FireWormAttackState : EnemyAttackState
{
    private FireWorm fireWorm;
    public FireWormAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        fireWorm = (FireWorm)enemy;
        timer = fireWorm.DelayAttackAnimation;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0)
        {
            fireWorm.InstantiateProjectile().GetComponent<FireWormProjectileSetUp>().Activate();
            timer = 1000;// to prevent activating again
        }
    }
}
