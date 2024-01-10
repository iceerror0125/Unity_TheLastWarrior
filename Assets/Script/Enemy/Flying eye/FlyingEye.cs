using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEye : FlyEnemy
{
    [SerializeField] private float attackVelocitySpeed;
    public bool isApproach { get; private set; }
    private Vector2 originalPosition;

    public float AttackSpeed => attackVelocitySpeed;
    public Vector2 OriginalPosition => originalPosition;
    public void SetOriginalPosition(Vector2 originalPosition) => this.originalPosition = originalPosition;
    public void SetIsApproach(bool value) => this.isApproach = value;

    protected override void Start()
    {
        base.Start();
        idleState = new EnemyIdleState(this, "FlyingEye_Idle");
        hurtState = new EnemyHurtState(this, "FlyingEye_Hit");
        deadState = new EnemyDeadState(this, "FlyingEye_Dead");
        attackState = new FlyingEyeAttackState(this, "FlyingEye_Attack");
        moveState = new FlyEnemyMoveState(this, "FlyingEye_Idle");
        battleState = new FlyingEyeBattleState(this, "FlyingEye_Idle");

        stateMachine.InitState(idleState);
    }


    /*public override void PerformNormalAttack(Entity hitEntity)
    {
        if (attackCount == 3) // the third attack will be further knockback
        {
            defautKnockback = new Vector2(10, 6);
            DefaultAttackCount();
        }
        else
        {
            defautKnockback = new Vector2(4, 4);
        }
        base.PerformNormalAttack(hitEntity);
    }*/
}
