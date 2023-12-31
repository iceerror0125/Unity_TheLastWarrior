
public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ZeroVelocity();
        player.SetIsDead(true);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}
