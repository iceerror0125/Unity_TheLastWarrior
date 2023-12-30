using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common3HurtState : Common3State
{
    public Common3HurtState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = common3.HurtTime;
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
            stateMachine.ChangeState(common3.battleState);
        }
    }
}
