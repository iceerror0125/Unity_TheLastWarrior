using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerGroundState : PlayerState
{

    public override void Enter()
    {
        base.Enter();
        player.SetCanDoubleJump(true);
        player.SetCanHighJump(true);
        player.ActivateFallGravity(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (!player.IsGround())
            return;
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            stateMachine.ChangeState(player.rollState);
        }

        if (Input.GetKeyDown(KeyCode.X) && timer < 0)
        {
            stateMachine.ChangeState(player.attackState);
        }
    }
}
