using UnityEngine;

[RequireComponent(typeof(EnemyStat))]
public class Enemy : Entity
{
    #region Enemy Setting
    [Header("Move")]
    [SerializeField] private float moveDuration;
    [SerializeField] private float idleDuration;
    [Header("Detect player")]
    [SerializeField] protected float detectPlayerDistance;
    [SerializeField] protected Vector2 additionalDetectPosition; // outside this tranform collider
    [SerializeField] protected bool isDetected;
    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected float exitBattleStateTime;
    [Header("Attack")]
    [SerializeField] protected float attackRange;
    [SerializeField] protected bool isAttack;
    #endregion
    #region State
    protected EnemyAttackState attackState;
    protected EnemyBattleState battleState;
    protected EnemyDeadState deadState;
    protected EnemyHurtState hurtState;
    protected EnemyIdleState idleState;
    protected EnemyMoveState moveState;
    #endregion
    public Player player { get; private set; }
    //public EnemyStat stat { get; private set; }


    #region Get Set
    public void SetIsDetectedPlayer(bool _value) => isDetected = _value;
    public bool IsDetected() => isDetected;
    public float ExitBattleStateTime => exitBattleStateTime;
    public bool IsAttack => isAttack;
    public void SetIsAttack(bool _value) => isAttack = _value;
    public float MoveDuration => moveDuration;
    public float IdleDuration => idleDuration;
    public EnemyAttackState AttackState => attackState;
    public EnemyBattleState BattleState => battleState;
    public EnemyDeadState DeadState => deadState;
    public EnemyHurtState HurtState => hurtState;
    public EnemyIdleState IdleState => idleState;
    public EnemyMoveState MoveState => moveState;
    #endregion

    protected override void Start()
    {
        base.Start();
        //stat = GetComponent<EnemyStat>();
        isFacingRight = true;
        player = PlayerManager.instance.player;

    }
    protected override void Update()
    {
        base.Update();

    }
    public void Flip()
    {
        isFacingRight = !isFacingRight;
        ChangeRotation();
    }
    public bool IsPlayerInAttackRange()
    {
        var collider = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);
        if (collider != null && collider.GetComponent<Player>()?.stat.IsDead == false)
        {
            return true;
        }
        return false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public bool IsOnTheRightOfPlayer()
    {
        if (transform.position.x - 0.4 > player.transform.position.x)
        {
            return true;
        }
        
        return false;
    }
    public void TurnToPlayer()
    {
        if (EntityDir > 0 && IsOnTheRightOfPlayer())
        {
            Flip();
        }
        else if (EntityDir < 0 && !IsOnTheRightOfPlayer())
        {
            Flip();
        }
    }

}
