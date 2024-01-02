
public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
        player.SetIsInDeadState(true);
    }

    public override void Exit()
    {
        base.Exit();
        player.SetIsInDeadState(false);

    }

    public override void Update()
    {
        base.Update();
    }
}
