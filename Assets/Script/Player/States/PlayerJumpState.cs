
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    public PlayerJumpState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ActivateFallGravity(false);

        Jump(player.JumpForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
      
        CheckingChangeToFallState();
    }

    private void CheckingChangeToFallState()
    {

        if (player.rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.fallState);
        }
        if (Input.GetKeyUp(KeyCode.Z) && player.rb.velocity.y > 0)
        {
            player.ChangeVelocity(new Vector2(player.rb.velocity.x, 0));
        }
      
    }

    private void Jump(float yValue)
    {
        Vector2 jump = new Vector2(
           player.rb.velocity.x,
           yValue
           );
        player.ChangeVelocity(jump);
    }
}
