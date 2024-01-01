using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class EnemyBattleState : EnemyState
{
    float exitBattleStateTimer;
    protected Player player;
    public EnemyBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        exitBattleStateTimer = enemy.ExitBattleStateTime;
        enemy.SetIsDetectedPlayer(true);
        enemy.SetIsAttack(false);
        /*enemy.ZeroVelocity();
        // To revent enemy turn to player immediately
        timer = 0.2f;*/
        player = PlayerManager.instance.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        
        TransitionStateCheck();
        enemy.TurnToPlayer();
    }

    protected virtual void TransitionStateCheck()
    {
        exitBattleStateTimer -= Time.deltaTime;

        if (exitBattleStateTimer < 0 || player.IsDead)
        {
            stateMachine.ChangeState(enemy.IdleState);
        }

        if (enemy.IsPlayerInAttackRange())
        {
            stateMachine.ChangeState(enemy.AttackState);
        }
    }

}
