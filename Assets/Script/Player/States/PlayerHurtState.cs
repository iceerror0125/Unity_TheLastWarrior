using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = player.HurtTime;
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
            stateMachine.ChangeState(player.idleState);
        }
    }
}
