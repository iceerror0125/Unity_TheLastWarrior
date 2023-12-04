using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Component
    public Rigidbody2D rb { get; private set; }
    public Animator anim { get; private set; }
    #endregion

    #region PlayerState
    public PlayerIdleState idleState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerGroundState groundState { get; private set; }
    public PlayerFallState fallState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerGroundState rollState { get; private set; }
    public PlayerAttackState attackState { get; private set; }
    #endregion

    #region Player setting

    [SerializeField] private float yVelocity;

    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDir;
    [SerializeField] private bool isFacingRight;
    [Header("Check surface")]
    [SerializeField] private bool isGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckLength;
    [SerializeField] private LayerMask whatIsGround;
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpConstant;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private bool canHighJump;
    [SerializeField] private float moveSpeedInAir;


    [Header("Fall")]
    [SerializeField] private float fallGravity;
    [SerializeField] private float defaultGravity;
    [Header("Roll")]
    [SerializeField] private float rollSpeed;
    [SerializeField] private bool isRolling;

    [Header("Attack")]
    [SerializeField] private float attackCountdown;
    [SerializeField] private bool isFirstAttack;
    [SerializeField] private float attackDir;

    #endregion

    public StateMachine stateMachine { get; private set; }

    private void Awake()
    {
        stateMachine = new StateMachine();
    }

    private void Start()
    {
        #region Get Component

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();

        #endregion

        #region Init Player State

        idleState = new PlayerIdleState("Player_Idle");
        moveState = new PlayerMoveState("Player_Run");
        jumpState = new PlayerJumpState("Player_Jump");
        fallState = new PlayerFallState("Player_Fall");
        rollState = new PlayerRollState("Player_Roll");
        attackState = new PlayerAttackState("Player_Attack1");
        #endregion

        stateMachine.InitState(idleState);
        isFacingRight = true;
        canDoubleJump = true;
        canHighJump = true;
    }


    private void Update()
    {
        moveDir = Input.GetAxisRaw("Horizontal");
        stateMachine.currentState.Update();

        yVelocity = rb.velocity.y;

        CheckGround();
    }

    public void ZeroVelocity() => rb.velocity = Vector2.zero;
    public void ChangeVelocity(Vector2 _newVelocity) => rb.velocity = _newVelocity;
    public float MoveSpeed() => moveSpeed;
    public float MoveDir() => moveDir;
    public float JumpForce() => jumpForce;
    public float RollSpeed() => rollSpeed;
    public bool IsGround() => isGround;
    public bool IsRolling() => isRolling;
    public void SetIsRolling(bool _isRolling) => isRolling = _isRolling;
    public bool IsFacingRight() => isFacingRight;
    public float MoveSpeedInAir() => moveSpeedInAir;
    public float AttackCountDown() => attackCountdown;
    public bool IsFirstAttack() => isFirstAttack;
    public float AttackDir() => attackDir;
    public bool CanDoubleJump() => canDoubleJump;
    public void SetCanDoubleJump(bool _canDoubleJump) => canDoubleJump = _canDoubleJump;
    public bool CanHighJump() => canHighJump;
    public void SetCanHighJump(bool _canHighJump) => canHighJump = _canHighJump;
    public float SetAttackDir(float _attackDir) => attackDir = _attackDir;
    public void SetIsFirstAttack(bool _isFirstAttack) => isFirstAttack = _isFirstAttack;
    public void SetIsGround(bool _isGround) => isGround = _isGround;
    public float JumpConstant() => jumpConstant;


    public void SetIsFacingRight(bool _isFacingRight)
    {
        if (_isFacingRight != isFacingRight)
        {
            transform.Rotate(0, 180, 0);
            isFacingRight = _isFacingRight;
        }
    }
    public void ActivateFallGravity(bool _isActivate)
    {
        if (_isActivate)
        {
            rb.gravityScale = fallGravity;
        }
        else
        {
            rb.gravityScale = defaultGravity;
        }
    }

    public void CheckGround()
    {
        isGround = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckLength,
            whatIsGround
            );
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(
            groundCheck.position,
            new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckLength)
            );
    }
}
