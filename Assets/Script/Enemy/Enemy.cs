using System.Collections.Generic;
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
    [SerializeField] protected LayerMask whatIsPlayer = 1 << 6;
    [SerializeField] protected float exitBattleStateTime;
    [Header("Attack")]
    [SerializeField] protected float attackRange;
    [SerializeField] protected bool isAttack;
    [Header("Additional Skill")]
    [SerializeField] protected int attackCount; // active special skill when attackCount = x
    [SerializeField] protected List<EnemyState> skillList;
    protected int skillIndex;
    [Header("Boss")]
    [SerializeField] protected bool isBoss;
    public bool isActivePhase2 { get; protected set; }

    #endregion

    #region State
    public EnemyAttackState attackState { get; protected set; }
    public EnemyBattleState battleState { get; protected set; }
    public EnemyDeadState deadState { get; protected set; }
    public EnemyHurtState hurtState { get; protected set; }
    public EnemyIdleState idleState { get; protected set; }
    public EnemyMoveState moveState { get; protected set; }
    #endregion

    public Player player { get; private set; }
    //public EnemyStat stat { get; private set; }


    #region Get Set
    public void SetIsDetectedPlayer(bool _value) => isDetected = _value;
    public bool IsDetected => isDetected;
    public float ExitBattleStateTime => exitBattleStateTime;
    public bool IsAttack => isAttack;
    public void SetIsAttack(bool _value) => isAttack = _value;
    public float MoveDuration => moveDuration;
    public float IdleDuration => idleDuration;
    public float DetectPlayerDistance => detectPlayerDistance;
    public int AttackCount => attackCount;
    #endregion

    protected override void Start()
    {
        base.Start();
        //stat = GetComponent<EnemyStat>();
        isFacingRight = true;
        player = PlayerManager.instance.player;
        skillList = new List<EnemyState>();

    }
    protected override void Update()
    {
        base.Update();

        if (stat.Hp < stat.MaxHp / 2)
        {
            skillIndex = skillList.Count;
            if (!isActivePhase2)
            {
                ActivePhase2();
                isActivePhase2 = true;
            }
        }

        // test all monster 
        /*if (stat.Hp < 0)
        {
            stateMachine.ChangeState(deadState);
        }*/
    }

    protected virtual void ActivePhase2() { }

    public void ActivateSkill()
    {
        if (skillList.Count > 0) // some enemies don't have a skill
        {
            int index = Random.Range(0, skillIndex);
            stateMachine.ChangeState(skillList[index]);
            attackCount = 0;
        }
    }
    public bool CanUseSkill()
    {
        return skillList.Count > 0;
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        ChangeRotation();
    }
    public bool IsPlayerInAttackRange()
    {
        var collider = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);
        if (collider != null && collider.GetComponent<Player>()?.IsDead == false)
        {
            return true;
        }
        return false;
    }
    public void DefaultAttackCount()
    {
        attackCount = 0;
    }
    public void PlusAttackCount()
    {
        attackCount++;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    public bool IsOnTheRightOfPlayer()
    {
        return IsRightOfB(player);
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
    /* public override void KnockBack(Entity hitEntity, float x, float y)
     {
         base.KnockBack(hitEntity, x, y);

     }*/
    public override void KnockBack(Entity attacker, Vector2 knockback)
    {
        if (!isBoss)
        {
            stateMachine.ChangeState(hurtState);
        }
        else
        {
            float temp = moveSpeed;
            moveSpeed *= -1;
            StartCoroutine(RestoreSpeedRoutine(temp));
        }

        base.KnockBack(attacker, knockback);
        
    }
    private System.Collections.IEnumerator RestoreSpeedRoutine(float speed)
    {
        yield return new WaitForSeconds(0.5f);
        moveSpeed = speed;
    }
    public bool CheckGroundAhead()
    {
        if (groundCheckLength == 0)
        {
            // fly enemy no need to check ground
            return true;
        }
        Vector2 start = new Vector2(transform.position.x + 0.6f * entityDir, transform.position.y);
        var ray = Physics2D.Raycast(start, Vector2.down, groundCheckLength, whatIsGround);
        return ray;
    }

    public override void TakeDamage(float damage, bool isDeadZone = false)
    {
        base.TakeDamage(damage, isDeadZone);
        AudioManager.instance.environment.EnemyHurt();
    }
    public void DestroyOTA()
    {
        OneTimeAppear ota = GetComponent<OneTimeAppear>();
        if (ota != null)
        {
            ota.DestroyOTA();
        }
    }
    public void DestroyDropItem(DropItem di)
    {
        Destroy(di);
    }
}
