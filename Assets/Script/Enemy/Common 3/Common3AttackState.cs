using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Common3AttackState : Common3State
{
    public Common3AttackState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        common3.ZeroVelocity();
        common3.InstantiateProjectile().GetComponent<Common3ProjectileSetUp>().Activate();
      
        timer = 0.5f;
    }

    public override void Exit()
    {
        base.Exit();
        common3.SetToAttackStateTimer(common3.ToAttackStateCountdown);
    }

    public override void Update()
    {
        base.Update();

        if (timer < 0)
        {
            stateMachine.ChangeState(common3.battleState);
        }
    }
}
