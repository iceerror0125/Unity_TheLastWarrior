using UnityEngine;

public class PlayerRollState : PlayerGroundState
{
    private int facingValue;

    public PlayerRollState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetIsRolling(true);
        facingValue = player.IsFacingRight ? 1 : -1;
    }

    public override void Exit()
    {
        base.Exit();
        player.SetIsRolling(false);
    }

    public override void Update()
    {
        if (player.IsRolling)
        {
            player.ChangeVelocity(new Vector2(player.RollSpeed * facingValue, player.rb.velocity.y));
            return;
        }
          
        base.Update();
    }
}
