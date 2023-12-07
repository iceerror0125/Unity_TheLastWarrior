using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1HurtState : Common1State
{
    public Common1HurtState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = common1.HurtTime;
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
            stateMachine.ChangeState(common1.battleState);
        }
    }
}
