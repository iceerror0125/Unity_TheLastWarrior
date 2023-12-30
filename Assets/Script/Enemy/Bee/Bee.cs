using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : FlyEnemy
{
    #region State
    public BeeAttackState attackState { get; private set; }
    public BeeBattleState battleState { get; private set; }
    public BeeDeadState deadState { get; private set; }
    public BeeIdleState idleState { get; private set; }
    public BeeMoveState moveState { get; private set; }
    #endregion

    [Header("Move")]
    [SerializeField] private float moveDuration;
    [SerializeField] private float idleDuration;

    [Header("Attack")]
    [SerializeField] private GameObject projectile;

    [Header("Battle State")]
    [SerializeField] private float distanceStopMoving;
    [SerializeField] private float toAttackStateCountdown;
    [SerializeField] private float moveBackwardSpeed;
    private float toAttackStateTimer;

    public GameObject Projectile => projectile;
    public float MoveDuration() => moveDuration;
    public float IdleDuration() => idleDuration;
    public float DistanceStopMoving => distanceStopMoving;
    public float ToAttackStateCountdown => toAttackStateCountdown;
    public float ToAttackStateTimer => toAttackStateTimer;
    public float SetToAttackStateTimer(float _value) => toAttackStateTimer = _value;
    public float MoveBackwardSpeed => moveBackwardSpeed;
    protected override void Start()
    {
        base.Start();
        attackState = new BeeAttackState("Bee_Attack");
        battleState = new BeeBattleState("Bee_Move");
        deadState = new BeeDeadState("Bee_Dead");
        idleState = new BeeIdleState("Bee_Idle");
        moveState = new BeeMoveState("Bee_Move");

        stateMachine.InitState(idleState);
    }

    protected override void Update()
    {
        base.Update();
        if (DetectPlayer() && isDetected == false && !PlayerManager.instance.player.stat.IsDead)
        {
            stateMachine.ChangeState(battleState);
        }

        if (stat.IsDead)
        {
            stateMachine.ChangeState(deadState);
        }
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
