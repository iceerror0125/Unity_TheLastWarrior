using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : GroundEnemy
{
    [Header("Skeleton Setting")]
    [SerializeField] private bool isShield;
    [SerializeField] private float useShieldDuration;
    public bool isAttackImmediately { get; private set; }

    public SkeletonShieldState shieldState { get; private set; }

    public bool IsShield => isShield;
    public float UseShieldDuration => useShieldDuration;
    public void SetIsShield(bool value) => isShield = value;
    public void SetAttackImmediately(bool value) => isAttackImmediately = value;

    protected override void Start()
    {
        base.Start();
        attackState = new EnemyAttackState(this, "Skeleton_Attack");
        deadState = new EnemyDeadState(this, "Skeleton_Dead");
        battleState = new SkeletonBattleState(this, "Skeleton_Move");
        hurtState = new EnemyHurtState(this, "Skeleton_Hit");
        idleState = new EnemyIdleState(this, "Skeleton_Idle");
        moveState = new EnemyMoveState(this, "Skeleton_Move");
        shieldState = new SkeletonShieldState(this, "Skeleton_Shield");

        stateMachine.InitState(idleState);

        isAttackImmediately = false;
    }

    public override void KnockBack(Entity _attacker, float x, float y)
    {
        if (isShield)
        {
            float dir = IsOnTheRightOfPlayer() ? 1 : -1;
            if (dir == entityDir * -1)
            {
                return;
            }
        }

        base.KnockBack(_attacker, x, y);
    }
}
