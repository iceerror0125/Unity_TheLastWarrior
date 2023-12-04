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
        player.SetCanHighJump(false);
        player.ActivateFallGravity(true);
    }

    public override void Exit()
    {
        base.Exit();
        player.ActivateFallGravity(false);
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
