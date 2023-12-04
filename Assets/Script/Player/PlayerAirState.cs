using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
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
        MoveController(player.MoveSpeedInAir());

        if (player.CanDoubleJump())
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("Double Jump");
                player.ActivateFallGravity(false);
                player.SetCanDoubleJump(false);
                stateMachine.ChangeState(player.jumpState);
            }
        }
    }
}
