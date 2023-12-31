using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Common1 : GroundEnemy
{
    protected override void Start()
    {
        base.Start();

        #region Init Common 1 State
        attackState = new EnemyAttackState(this, "Common1_Attack");
        battleState = new EnemyBattleState(this, "Common1_Walk");
        idleState = new EnemyIdleState(this, "Common1_Idle");
        moveState = new EnemyMoveState(this, "Common1_Walk");
        deadState = new EnemyDeadState(this, "Common1_Dead");
        hurtState = new EnemyHurtState(this, "Common1_Hurt");
        #endregion

        stateMachine.InitState(idleState);
    }

    public override void KnockBack(Entity _attacker, float x, float y)
    {
        base.KnockBack(_attacker, x, y);
        stateMachine.ChangeState(hurtState);
    }
}
