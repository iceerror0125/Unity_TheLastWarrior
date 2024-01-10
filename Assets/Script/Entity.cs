using System.Security.Principal;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class Entity : MonoBehaviour
{
    #region Component
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    #endregion

    #region Entity setting
    [Header("Move")]
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected float moveDir;
    [SerializeField] protected float entityDir;
    [SerializeField] protected bool isFacingRight;
    [SerializeField] private Vector2 moveRange;

    [Header("Ground Check")]
    [SerializeField] protected bool isGround;
    [SerializeField] protected float groundCheckLength;
    [SerializeField] protected LayerMask whatIsGround = 1 << 3;

    [Header("Wall Check")]
    [SerializeField] protected bool isWall;
    [SerializeField] protected float wallCheckLength;

    [Header("Roll")]
    [SerializeField] protected float rollSpeed;
    [SerializeField] protected bool isRolling;

    [Header("Attack")]
    [SerializeField] protected float attackCountdown;
    [SerializeField] protected Transform attackCheck;
    [SerializeField] protected float attackCheckRadius;
    [SerializeField] private float hurtTime = 0.5f;
    protected Vector2 defautKnockback = new Vector2(4, 4);
    public bool canKnockback;

    [Header("Dead")]
    [SerializeField] protected bool isDead;



    [Header("UnDead")]
    [SerializeField] public bool isImmortal;
    public bool isInDeadState { get; private set; } // to prevent entering deadState multiple times
    #endregion

    public StateMachine stateMachine { get; private set; }
    public EntityStat stat { get; private set; }

    #region Getter Setter
    public float MoveSpeed => moveSpeed;
    public float MoveDir => moveDir;
    public float SetMoveDir(float _value) => moveDir = _value;
    public float RollSpeed => rollSpeed;
    public bool IsGround => isGround;
    public void SetIsGround(bool _isGround) => isGround = _isGround;
    public bool IsWall => isWall;
    public bool IsRolling => isRolling;
    public void SetIsRolling(bool _isRolling) => isRolling = _isRolling;
    public bool IsFacingRight => isFacingRight;
    public float EntityDir => entityDir;
    public float AttackCountDown => attackCountdown;
    public float SetAttackCountdown(float _value) => attackCountdown = _value;
    public Transform AttackCheck => attackCheck;
    public float AttackCheckRadius => attackCheckRadius;
    public float HurtTime => hurtTime;
    public bool IsDead => isDead;
    public void SetIsDead(bool _value) => isDead = _value;
    public Vector2 MoveRange => moveRange;
    public void SetIsInDeadState(bool value) => isInDeadState = value;
    public void SetAttackCheckRadius(float value) => attackCheckRadius = value;
    public void SetAttackCheckPosition(Vector2 value) => attackCheck.position = value;
    #endregion

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();

        #region Get Component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stat = GetComponent<EntityStat>();
        #endregion
        // rb.gravityScale = 4;
        isDead = false;
        isInDeadState = false;
       
    }

    protected virtual void Start() { }
    protected virtual void Update()
    {
        if (stateMachine != null)
            stateMachine.currentState.Update();

        entityDir = isFacingRight ? 1 : -1;

        CheckingGround();
        CheckingWall();
    }
    private void CheckingGround()
    {
        isGround = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            groundCheckLength,
            whatIsGround
            );
    }
    private void CheckingWall()
    {
        isWall = Physics2D.Raycast(transform.position,
            Vector2.right * entityDir,
            wallCheckLength,
            whatIsGround);
    }
    protected virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(
            transform.position,
            new Vector2(transform.position.x, transform.position.y - groundCheckLength)
            );
        Gizmos.DrawLine(
            transform.position,
            new Vector2(transform.position.x + wallCheckLength * entityDir, transform.position.y)
            );
        Gizmos.DrawWireSphere(attackCheck.position, attackCheckRadius);
    }
    public void ChangeRotation()
    {
        transform.Rotate(0, 180, 0);
    }
    public void SetIsFacingRight(bool isFacingRight)
    {
        this.isFacingRight = isFacingRight;
    }
    public void ZeroVelocity() => rb.velocity = Vector2.zero;
    public void ChangeVelocity(Vector2 newVelocity) => rb.velocity = newVelocity;
    public void ChangeVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
    }
    public virtual bool IsRightOfB(Entity b)
    {
        if (transform.position.x - 0.4 > b.transform.position.x)
        {
            return true;
        }

        return false;
    }

    public virtual void KnockBack(Entity hitEntity, float x, float y)
    {
        if (!hitEntity.canKnockback)
            return;
        // knockback in a direction versus position of attacker
        float knockbackDir = IsRightOfB(this) == true ? 1 : -1;
        Vector2 hit = new Vector2(x * knockbackDir, y);
        ChangeVelocity(hit);

        hitEntity.canKnockback = false;
    }
    public virtual void KnockBack(Entity attacker, Vector2 knockback)
    {
        float knockbackDir = IsRightOfB(attacker) == true ? 1 : -1;
        Vector2 hit = new Vector2(knockback.x * knockbackDir, knockback.y);
        ChangeVelocity(hit);
    }

    // Use Entity as Interface and Stat is Interface implement
   /* public virtual void PerformNormalAttack(Entity hitEntity)
    {
        stat.PerformNormalAttack(hitEntity);
        //hitEntity.KnockBack(this, defautKnockback.x, defautKnockback.y);
        hitEntity.KnockBack(hitEntity, defautKnockback.x, defautKnockback.y);
    }
    public virtual void PerformSpellAttack(Entity hitEntity, float damage)
    {
        stat.PerformSpellAttack(hitEntity, damage);
        hitEntity.KnockBack(this, defautKnockback.x, defautKnockback.y);
    }
    public virtual void PerformSpellAttack(Entity hitEntity, float damage, Vector2 knockBack)
    {
        stat.PerformSpellAttack(hitEntity, damage);
        hitEntity.KnockBack(this, knockBack.x, knockBack.y);
    }*/
    public virtual void CauseDamage(Entity hitEntity, float damage = 0, bool isCrit = false, Vector2 knockBack = default)
    {
        damage = damage == 0 ? stat.Damage : damage;
        if (stat.DoesCauseDamage(hitEntity, damage, isCrit))
        {
            if (knockBack == Vector2.zero)
                hitEntity.KnockBack(this, defautKnockback);
            else
                hitEntity.KnockBack(this, knockBack);
        }
    }
    public virtual void RecoverHP(float recoverHP)
    {
        stat.RecoverHP(recoverHP);
    }
    public virtual void TakeDamage(float damage)
    {
        stat.TakeDamage(damage);
    }
}
