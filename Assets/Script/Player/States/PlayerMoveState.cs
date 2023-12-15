using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(string _animName)
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

        MoveController(player.MoveSpeed());

        if (player.MoveDir() == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
