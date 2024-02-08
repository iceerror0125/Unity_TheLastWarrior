
public class PlayerHurtState : PlayerState
{
    public PlayerHurtState(string animName) : base(animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = player.HurtTime;
        player.isImmortal = true;
    }

    public override void Exit()
    {
        base.Exit();
        player.isImmortal = false;
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
