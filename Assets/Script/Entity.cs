using System;
using Unity.Mathematics;
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

    [Header("Ground Check")]
    [SerializeField] protected bool isGround;
    [SerializeField] protected float groundCheckLength;
    [SerializeField] protected LayerMask whatIsGround;


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
    private float hurtTime = 0.2f;

    private bool isDead;
    #endregion

    public StateMachine stateMachine { get; private set; }
    public EntityStat stat { get; private set; }

    #region Getter Setter
    public float MoveSpeed() => moveSpeed;
    public float MoveDir() => moveDir;
    public float SetMoveDir(float _value) => moveDir = _value;
    public float RollSpeed() => rollSpeed;
    public bool IsGround() => isGround;
    public void SetIsGround(bool _isGround) => isGround = _isGround;
    public bool IsWall() => isWall;
    public bool IsRolling() => isRolling;
    public void SetIsRolling(bool _isRolling) => isRolling = _isRolling;
    public bool IsFacingRight() => isFacingRight;
    public float EntityDir() => entityDir;
    public float AttackCountDown() => attackCountdown;
    public float SetAttackCountdown(float _value) => attackCountdown = _value;
    public Transform AttackCheck => attackCheck;
    public float AttackCheckRadius => attackCheckRadius;
    public float HurtTime => hurtTime;
    public bool IsDead => isDead;
    public void SetIsDead(bool _value) => isDead = _value;
    #endregion

    protected virtual void Awake()
    {
        stateMachine = new StateMachine();

        #region Get Component

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        stat = GetComponent<EntityStat>();
        rb.gravityScale = 4;
        #endregion
    }

    protected virtual void Start()
    {
       
    }

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

    public void SetIsFacingRight(bool _isFacingRight)
    {
        isFacingRight = _isFacingRight;
    }

    public void ZeroVelocity() => rb.velocity = Vector2.zero;
    public void ChangeVelocity(Vector2 _newVelocity) => rb.velocity = _newVelocity;
    public void ChangeVelocity(float x, float y)
    {
        rb.velocity = new Vector2(x, y);
    }
    
    public virtual void KnockBack(Entity _attacker, float x, float y)
    {
        Vector2 hit = new Vector2(x * _attacker.EntityDir(), y);
        ChangeVelocity(hit);
    }
    public virtual void Hit(Entity _hitEntity)
    {
        _hitEntity.KnockBack(this, 4, 4);
        stat.CauseDamageByNormalAttack(_hitEntity);
    }
    
    
}
