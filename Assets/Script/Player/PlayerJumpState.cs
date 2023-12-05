using System;
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
        player.ActivateFallGravity(false);

        Jump(player.JumpForce());
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
      

        CheckingChangeToFallState();
        Debug.Log("Jump State");
    }

    private void CheckingChangeToFallState()
    {

        if (player.rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
        if (Input.GetKeyUp(KeyCode.Z) && player.rb.velocity.y > 0)
        {
            player.ChangeVelocity(new Vector2(player.rb.velocity.x, 0/*player.rb.velocity.y / player.JumpConstant()*/));
        }
      
    }

    private void Jump(float _yValue)
    {
        Vector2 jump = new Vector2(
           player.rb.velocity.x,
           _yValue
           );
        player.ChangeVelocity(jump);
    }
}
