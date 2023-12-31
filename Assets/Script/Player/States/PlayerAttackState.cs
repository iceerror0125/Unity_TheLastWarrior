
public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(string animName) : base(animName)
    {
        player.SetIsFirstAttack(true);
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        player.timer = player.AttackCountDown;

        if (!player.IsFirstAttack)
        {
            animName = "Player_Attack2";
        }
        else
        {
            animName = "Player_Attack1";
        }
    }

    public override void Update()
    {
        base.Update();

        if (player.EntityDir != player.MoveDir)
        {
            player.ZeroVelocity();
        }
    }
}
