
using UnityEngine;

public class PlayerFallState : PlayerAirState
{
    public PlayerFallState(string animName) : base(animName)
    {
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

        if (player.CheckTagGround("Slippery"))
        {
            player.rb.gravityScale = 30;
            player.ZeroJumpCounter();
        }
        else
        {
            player.ActivateFallGravity(true);

        }
        if (player.IsGround)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
