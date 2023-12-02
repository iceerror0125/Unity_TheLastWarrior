using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PlayerGroundState : PlayerState
{

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

        if (!player.IsGround())
            return;
        
        if (Input.GetKey(KeyCode.Z))
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if (Input.GetKey(KeyCode.C))
        {
            stateMachine.ChangeState(player.rollState);
        }

        if (Input.GetKey(KeyCode.X) && timer < 0)
        {
            stateMachine.ChangeState(player.attackState);
        }
    }
}
