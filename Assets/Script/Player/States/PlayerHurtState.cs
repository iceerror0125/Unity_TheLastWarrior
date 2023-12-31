
public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = player.HurtTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
