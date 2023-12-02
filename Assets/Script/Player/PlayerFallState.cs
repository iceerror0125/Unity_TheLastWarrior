using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(string _animName)
    {
        this.animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.IsGround())
        {
            stateMachine.ChangeState(player.idleState);
        }
        Debug.Log("Fall State");
    }
}
