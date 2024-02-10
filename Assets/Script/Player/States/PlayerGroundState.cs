using UnityEngine;

public class PlayerGroundState : PlayerState
{
    public PlayerGroundState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroJumpCounter();
        player.SetCanHighJump(true);
        player.ActivateFallGravity(false);

        CameraManager.instance.InterpolateYAxis(false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        

        if (!player.IsGround)
        {
            player.stateMachine.ChangeState(player.fallState);
            return;
        }

        if (GameManager.Instance.isUITurnedOn)
        {
            return;
        }

        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            AudioManager.instance.player.Jump();
            stateMachine.ChangeState(player.jumpState);
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            stateMachine.ChangeState(player.rollState);
        }

        
    }
}
