using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundState
{
    public PlayerIdleState(string _animName)
    {
        this.animName = _animName;
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (player.MoveDir() !=0 )
        {
            stateMachine.ChangeState(player.moveState);
        }
        Debug.Log("Idle State");
    }
}
