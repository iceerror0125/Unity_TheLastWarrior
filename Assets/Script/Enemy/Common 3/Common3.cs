using UnityEngine;

public class Common3 : GroundEnemy
{
    [Header("Common 3 Battle State")]
    [SerializeField] private float distanceStopMoving;
    [SerializeField] private float toAttackStateCountdown;
    [SerializeField] private float moveBackwardSpeed;
    private float toAttackStateTimer;

    [Header("Common 3 Attack State")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed;

    #region Getter Setter
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

        attackState = new Common3AttackState(this, "Common3_Attack");
        deadState = new EnemyDeadState(this, "Common3_Dead");
        battleState = new Common3BattleState(this, "Common3_Move");
        hurtState = new EnemyHurtState(this, "Common3_Hit");
        idleState = new EnemyIdleState(this, "Common3_Idle");
        moveState = new EnemyMoveState(this, "Common3_Move");

        stateMachine.InitState(idleState);
    }
    protected override void Update()
    {
        base.Update(); 
    }
   
    public GameObject InstantiateProjectile()
    {
        return Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }
   
}
