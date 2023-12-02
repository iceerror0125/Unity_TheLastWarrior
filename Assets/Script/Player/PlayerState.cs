using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : BaseState
{
    protected Player player = PlayerManager.instance.player;

    public override void Enter()
    {
        base.Enter();
        stateMachine = player.stateMachine;

        player.anim.Play(animName);
    }

    public override void Update()
    {
        base.Update();
        Flip();
    }

    private void Flip()
    {
        if (player.MoveDir() != 0)
        {
            if (player.MoveDir() < 0)
                player.SetIsFacingRight(false);
            else if (player.MoveDir() > 0)
                player.SetIsFacingRight(true);
        }
    }

    protected void MoveController(float moveSpeed)
    {
        /*float facingValue = player.IsFacingRight() ? 1 : -1;
        if (player.MoveDir() != facingValue)
        {
            player.ChangeVelocity(player.ZeroVelocity());
            return;
        }*/

        Vector2 speed = new Vector2(
          moveSpeed * player.MoveDir(),
          player.rb.velocity.y
          );
        player.ChangeVelocity(speed);
    }
}
