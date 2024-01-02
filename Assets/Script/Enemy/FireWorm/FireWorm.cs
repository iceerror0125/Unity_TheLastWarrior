using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorm : GroundEnemy
{
    [Header("Fire worm battle setting")]
    [SerializeField] private float distanceStopMoving;
    [SerializeField] private float toAttackStateCountdown;
    [SerializeField] private float exitBattleDistance;

    [Header("Fire worm attack setting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float delayAttackAnimation = 1; // to match a attack animation


    [Header("Fire worm dead setting")]
    [SerializeField] private float explodeCountdown;
    //[SerializeField] private float explodeRad;



    public FireWormExplosionState explosionState { get; private set; }

    #region Getter Setter
    public float DistanceStopMoving => distanceStopMoving;
    public float ToAttackStateCountdown => toAttackStateCountdown;
    public GameObject ProjectilePrefab => projectilePrefab;
    public float ExitBattleDistance => exitBattleDistance;
    public float ExplodeCountdown => explodeCountdown;
    public float DelayAttackAnimation => delayAttackAnimation;
    #endregion

    protected override void Start()
    {
        base.Start();
        idleState = new EnemyIdleState(this, "FireWorm_Idle");
        moveState = new EnemyMoveState(this, "FireWorm_Move");
        hurtState = new EnemyHurtState(this, "FireWorm_Hit");
        attackState = new FireWormAttackState(this, "FireWorm_Attack");
        battleState = new FireWormBattleState(this, "FireWorm_Move");
        deadState = new FireWormDeadState(this, "FireWorm_Dead");
        explosionState = new FireWormExplosionState(this, "FireWorm_Explode");

        stateMachine.InitState(idleState);
    }
    protected override void Update()
    {
        base.Update();
    }

    public GameObject InstantiateProjectile()
    {
        return Instantiate(projectilePrefab, transform);
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        //Gizmos.DrawWireSphere(transform.position, explodeRad);
    }
}
