using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        timer = 0.2f;
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        MoveController(player.MoveSpeedInAir);

        CheckDoubleJump();
        if (timer < 0)
            CheckWallSlide();
    }

    protected void CheckWallSlide()
    {
        if (player.IsWall)
        {
            stateMachine.ChangeState(player.wallSlideState);
        }
    }

    private void CheckDoubleJump()
    {
        if (player.CanDoubleJump)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                player.ActivateFallGravity(false);
                player.SetCanDoubleJump(false);
                stateMachine.ChangeState(player.jumpState);
            }
        }
    }
}
