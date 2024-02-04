using UnityEngine;

public class PlayerAirState : PlayerState
{
    private bool isFall;
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
        isFall = false;
    }

    public override void Update()
    {
        base.Update();
        MoveController(player.MoveSpeedInAir);

        CheckDoubleJump();
        if (timer < 0)
            CheckWallSlide();

        if (player.rb.velocity.y < 0 && !isFall)
        {
            CameraManager.instance.InterpolateYAxis(true);
            isFall = true;
        }
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
                AudioManager.instance.player.Jump();
                player.ActivateFallGravity(false);
                player.SetCanDoubleJump(false);
                stateMachine.ChangeState(player.jumpState);
            }
        }
    }
}
