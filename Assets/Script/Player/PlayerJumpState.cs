using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(string _animName)
    {
        this.animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        //player.SetIsGround(false);

        Vector2 jump = new Vector2(
            player.rb.velocity.x,
            player.JumpForce()
            );
        player.ChangeVelocity(jump);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (player.rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }

        Debug.Log("Jump State");
    }
}
