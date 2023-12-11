using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1AttackState : Common1State
{
    public Common1AttackState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        common1.ZeroVelocity();
        common1.SetIsAttack(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (!common1.IsAttack)
        {
            stateMachine.ChangeState(common1.battleState);
        }
    }
}
