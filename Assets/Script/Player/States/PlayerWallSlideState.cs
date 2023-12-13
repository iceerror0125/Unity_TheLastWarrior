using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    float delayTime;
    bool wasPress;
    public PlayerWallSlideState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
        player.SetIsSliding(true);
        //player.rb.gravityScale = player.WallSlideGravity();
        player.SetIsFacingRight(!player.IsFacingRight());
        player.SetCanDoubleJump(true);
        player.SetCanHighJump(true);


        wasPress = false;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetIsSliding(false);
        player.ChangeRotation();

        Debug.Log("Exit Wall State");
    }

    public override void Update()
    {
        base.Update();
        player.ChangeVelocity(new Vector2(player.rb.velocity.x, player.WallSlideGravity()));


        CheckToGroundState();
        JumpOutWall();
    }

    private void JumpOutWall()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(player.wallJumpState);
        }
    }

    private void CheckToGroundState()
    {
        if (player.IsGround())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
