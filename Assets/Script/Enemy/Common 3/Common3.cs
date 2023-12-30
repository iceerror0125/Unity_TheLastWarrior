using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Common3 : GroundEnemy
{

    #region State
    public Common3AttackState attackState { get; private set; }
    public Common3BattleState battleState { get; private set; }
    public Common3HurtState hurtState { get; private set; }
    public Common3IdleState idleState { get; private set; }
    public Common3MoveState moveState { get; private set; }
    public Common3DeadState deadState { get; private set; }
    #endregion

    [Header("Move")]
    [SerializeField] private float moveDuration;
    [SerializeField] private float idleDuration;

    [Header("Battle State")]
    [SerializeField] private float distanceStopMoving;
    [SerializeField] private float toAttackStateCountdown;
    [SerializeField] private float moveBackwardSpeed;
    private float toAttackStateTimer;

    [Header("Attack State")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;





    #region Getter Setter
    public float MoveDuration() => moveDuration;
    public float IdleDuration() => idleDuration;
    public float DistanceStopMoving => distanceStopMoving;
    public float ToAttackStateCountdown => toAttackStateCountdown;
    public float ToAttackStateTimer => toAttackStateTimer;
    public float SetToAttackStateTimer(float _value) => toAttackStateTimer = _value;
    public float MoveBackwardSpeed => moveBackwardSpeed;
    public GameObject ProjectilePrefab => projectilePrefab;
    public float ProjectileSpeed => projectileSpeed;    
    #endregion
    protected override void Start()
    {
        base.Start();

        attackState = new Common3AttackState("Common3_Attack");
        deadState = new Common3DeadState("Common3_Dead");
        battleState = new Common3BattleState("Common3_Move");
        hurtState = new Common3HurtState("Common3_Hit");
        idleState = new Common3IdleState("Common3_Idle");
        moveState = new Common3MoveState("Common3_Move");

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
        stateMachine.ChangeState(hurtState);
    }

    public GameObject InstantiateProjectile()
    {
        return Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
   
}
