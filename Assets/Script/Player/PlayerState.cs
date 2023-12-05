using System;
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
        if (player.MoveDir() != 0 && !player.IsSliding())
        {
            if (player.MoveDir() != player.PlayerDir())
            {
                player.SetIsFacingRight(player.MoveDir() == -1 ? false : true);
                player.ChangeRotation();
            }
        }
    }

    protected virtual void MoveController(float _moveSpeed)
    {
        Vector2 speed = new Vector2(
          _moveSpeed * player.MoveDir(),
          player.rb.velocity.y
          );
        player.ChangeVelocity(speed);
    }

}
