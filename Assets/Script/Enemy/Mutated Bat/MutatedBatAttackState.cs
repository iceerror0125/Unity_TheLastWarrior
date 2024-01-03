using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class MutatedBatAttackState : EnemyAttackState
{
    MutatedBat bat;
    public MutatedBatAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bat = (MutatedBat)enemy;
       
        bat.InstantiateProjectile().GetComponent<MutatedBatProjectileSetUp>().Activate(bat);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
