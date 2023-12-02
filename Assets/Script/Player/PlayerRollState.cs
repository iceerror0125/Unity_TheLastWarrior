using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRollState : PlayerGroundState
{
    private int facingValue;
    public PlayerRollState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        player.SetIsRolling(true);
        facingValue = player.IsFacingRight() ? 1 : -1;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetIsRolling(false);
    }

    public override void Update()
    {
        if (player.IsRolling())
        {
            player.ChangeVelocity(new Vector2(player.RollSpeed() * facingValue, 0));
            return;
        }
          
        base.Update();
    }
}
