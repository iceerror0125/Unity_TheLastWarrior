using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeAttackState : EnemyAttackState
{
    Bee bee;
    public BeeAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bee = (Bee)enemy;
        bee.InstantiateProjectile().GetComponent<BeeProjectileSetUp>().Activate();
    }

    public override void Exit()
    {
        base.Exit();
        bee.SetToAttackStateTimer(bee.ToAttackStateCountdown);
    }

    public override void Update()
    {
        base.Update();
        Debug.Log("Attack State");
    }
}
