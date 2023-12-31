using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : FlyEnemy
{
    [Header("Bee Attack Setting")]
    [SerializeField] private GameObject projectile;

    [Header("Bee Battle Setting")]
    [SerializeField] private float distanceStopMoving;
    [SerializeField] private float toAttackStateCountdown;
    [SerializeField] private float moveBackwardSpeed;
    private float toAttackStateTimer;

    public GameObject Projectile => projectile;
    public float DistanceStopMoving => distanceStopMoving;
    public float ToAttackStateCountdown => toAttackStateCountdown;
    public float ToAttackStateTimer => toAttackStateTimer;
    public float SetToAttackStateTimer(float _value) => toAttackStateTimer = _value;
    public float MoveBackwardSpeed => moveBackwardSpeed;
    protected override void Start()
    {
        base.Start();
        attackState = new BeeAttackState(this, "Bee_Attack");
        battleState = new BeeBattleState(this, "Bee_Move");
        deadState = new EnemyDeadState(this, "Bee_Dead");
        idleState = new EnemyIdleState(this, "Bee_Idle");
        moveState = new EnemyMoveState(this, "Bee_Move");

        stateMachine.InitState(idleState);
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void KnockBack(Entity _attacker, float x, float y)
    {
        base.KnockBack(_attacker, x, y);
        //stateMachine.ChangeState(hurtState);
    }

    public GameObject InstantiateProjectile()
    {
        return Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
