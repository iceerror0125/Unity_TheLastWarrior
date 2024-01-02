
public class EnemyIdleState : EnemyState
{
    private bool hasFlip;
    public EnemyIdleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }
    public void SetHasFlip(bool _hasFlip) => hasFlip = _hasFlip;
    private void Flip()
    {
        enemy.ChangeRotation();
        enemy.SetIsFacingRight(!enemy.IsFacingRight);
    }
    public override void Enter()
    {
        base.Enter();
        timer = enemy.IdleDuration;
        enemy.SetIsDetectedPlayer(false);
    }

    public override void Exit()
    {
        base.Exit();
        hasFlip = false;
    }

    public override void Update()
    {
        base.Update();
        enemy.ZeroVelocity();
        if (timer < 0)
        {
            if (hasFlip)
                Flip();
            stateMachine.ChangeState(enemy.moveState);
        }
    }
}
