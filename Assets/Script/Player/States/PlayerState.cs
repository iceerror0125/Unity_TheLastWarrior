using System.Xml;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : BaseState
{
    //protected Player player = PlayerManager.instance.player;
    protected Player player;
    public PlayerState(string animName) : base(animName)
    {
        player = PlayerManager.instance.player;
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine = player.stateMachine;
        player.anim.Play(animName);
    }

    public override void Update()
    {
        base.Update();
        if (GameManager.Instance.isUITurnedOn)
        {
            return;
        }

        Flip();

        if (player.IsDead && !player.isInDeadState)
        {
            stateMachine.ChangeState(player.deadState);
        }
        if (Input.GetKeyDown(KeyCode.X) && player.timer < 0)
        {
            stateMachine.ChangeState(player.attackState);
        }
    }

    private void Flip()
    {
        if (player.MoveDir != 0 && !player.IsSliding)
        {
            if (player.MoveDir != player.EntityDir)
            {
                player.SetIsFacingRight(player.MoveDir == -1 ? false : true);
                player.ChangeRotation();
            }
        }
    }

    protected virtual void MoveController(float moveSpeed)
    {
        Vector2 speed = new Vector2(
          moveSpeed * player.MoveDir,
          player.rb.velocity.y
          );
        player.ChangeVelocity(speed);
    }

    
}
