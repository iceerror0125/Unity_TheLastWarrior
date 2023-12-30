using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BeeAttackState : BeeState
{
    public BeeAttackState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        bee.InstantiateProjectile().GetComponent<BeeProjectileSetUp>().Activate();
        timer = 0.5f;
    }

    public override void Exit()
    {
        base.Exit();
        bee.SetToAttackStateTimer(bee.ToAttackStateCountdown);
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0)
        {
            stateMachine.ChangeState(bee.battleState);
        }
    }
}
