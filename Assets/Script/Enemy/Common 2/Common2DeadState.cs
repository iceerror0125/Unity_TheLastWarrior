using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common2DeadState : Common2State
{
   public Common2DeadState(string _animName)
    {
        animName = _animName;
    }

    public override void Enter()
    {
        base.Enter();
        common2.SetIsInDeadState(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        common2.ZeroVelocity();
    }
}
