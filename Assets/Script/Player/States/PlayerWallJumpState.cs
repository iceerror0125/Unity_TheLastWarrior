using UnityEngine;

public class PlayerWallJumpState : PlayerAirState
{
    private float activeMoveControllerTimer;

    public PlayerWallJumpState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        float x = player.WallSlideJumpForce * player.EntityDir;
        float y = x * x;
        var jumpVector = new Vector2(x, y);
        player.ChangeVelocity(jumpVector);

        activeMoveControllerTimer = 0.2f;

        player.PlusJumpCounter();

        AudioManager.instance.player.Jump();

    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        activeMoveControllerTimer -= Time.deltaTime;

        MoveController(player.MoveSpeedInAir);


        JumpController();

        if (player.rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }

    }

    protected override void MoveController(float moveSpeed)
    {
        if (player.MoveDir == 0)
        {
            player.SetMoveDir(player.EntityDir);
            return;
        }
        if (activeMoveControllerTimer < 0)
            base.MoveController(moveSpeed);
    }

    private void JumpController()
    {
        if (Input.GetKeyUp(KeyCode.Z))
        {
            if (Input.GetKeyUp(KeyCode.Z) && player.rb.velocity.y > 0)
            {
                player.ChangeVelocity(new Vector2(player.rb.velocity.x, 0));
            }
        }
    }
}
