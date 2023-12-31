using UnityEngine;

public class Common3BattleState : EnemyBattleState
{
    float exitBattleStateTimer;
    float distanceStopMoving;
    float moveBackwardSpeed;

    Player player;
    Common3 common3;

    public Common3BattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        common3 = (Common3)enemy;
        player = PlayerManager.instance.player;

        common3.SetIsDetectedPlayer(true);

        timer = common3.ToAttackStateTimer;
        exitBattleStateTimer = common3.ExitBattleStateTime;
        distanceStopMoving = common3.DistanceStopMoving;
        moveBackwardSpeed = common3.MoveBackwardSpeed;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        common3.TurnToPlayer();
        MoveController();
        TransitionStateCheck();
        ExitStateCheck();

        if (timer < 0 && common3.DetectPlayer()) 
        {
            stateMachine.ChangeState(common3.AttackState);
        }
    }

    private void ExitStateCheck()
    {
        exitBattleStateTimer -= Time.deltaTime;
        if (exitBattleStateTimer < 0)
        {
            stateMachine.ChangeState(common3.IdleState);
        }
    }

    private void MoveController()
    {
        // Stop gi gi do
        if (common3.DetectPlayer())
        {
            common3.ZeroVelocity();
        }
        else
        {
            common3.ChangeVelocity(common3.MoveSpeed * common3.EntityDir, common3.rb.velocity.y);
        }
    }

   
    private void TransitionStateCheck()
    {
        if (exitBattleStateTimer < 0 || player.stat.IsDead)
        {
            stateMachine.ChangeState(common3.IdleState);
        }
    }
}
