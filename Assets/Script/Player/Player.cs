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
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    #endregion

    #region Player setting

    [SerializeField] private float yVelocity;

    [Header("Wall Slide")]
    [SerializeField] private float wallSlideGravity;
    [SerializeField] private float wallSlideJumpForce;
    [SerializeField] private bool isSliding;


    [Header("Move")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float moveDir;
    [SerializeField] private float playerDir;
    [SerializeField] private bool isFacingRight;

    [Header("Ground Check")]
    [SerializeField] private bool isGround;
    [SerializeField] private float groundCheckLength;
    [SerializeField] private LayerMask whatIsGround;

    [Header("Wall Check")]
    [SerializeField] private bool isWall;
    [SerializeField] private float wallCheckLength;
    // [SerializeField] private LayerMask whatIsGround;

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
        wallSlideState = new PlayerWallSlideState("Player_WallSlide");
        deadState = new PlayerDeadState("Player_Death");
        wallJumpState = new PlayerWallJumpState("Player_Jump");
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
        playerDir = isFacingRight ? 1 : -1;

        CheckingGround();
        CheckingWall();
    }

    public void ZeroVelocity() => rb.velocity = Vector2.zero;
    public void ChangeVelocity(Vector2 _newVelocity) => rb.velocity = _newVelocity;
    public float MoveSpeed() => moveSpeed;
    public float MoveDir() => moveDir;
    public float SetMoveDir(float _value) => moveDir = _value; 
    public float JumpForce() => jumpForce;
    public float RollSpeed() => rollSpeed;
    public bool IsGround() => isGround;
    public bool IsRolling() => isRolling;
    public void SetIsRolling(bool _isRolling) => isRolling = _isRolling;
    public bool IsFacingRight() => isFacingRight;
    public float MoveSpeedInAir() => moveSpeedInAir;
    public float AttackCountDown() => attackCountdown;
    public bool IsFirstAttack() => isFirstAttack;
    public bool CanDoubleJump() => canDoubleJump;
    public void SetCanDoubleJump(bool _canDoubleJump) => canDoubleJump = _canDoubleJump;
    public bool CanHighJump() => canHighJump;
    public void SetCanHighJump(bool _canHighJump) => canHighJump = _canHighJump;
    public void SetIsFirstAttack(bool _isFirstAttack) => isFirstAttack = _isFirstAttack;
    public void SetIsGround(bool _isGround) => isGround = _isGround;
    public float JumpConstant() => jumpConstant;
    public bool IsWall() => isWall;
    public float PlayerDir() => playerDir;
    public float WallSlideGravity() => wallSlideGravity;
    public float WallSlideJumpForce() => wallSlideJumpForce;
    public bool IsSliding() => isSliding;
    public void SetIsSliding(bool _value) => isSliding = _value;

    public void ChangeRotation()
    {
        transform.Rotate(0, 180, 0);
    }

    public void SetIsFacingRight(bool _isFacingRight)
    {
        isFacingRight = _isFacingRight;
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
            Vector2.right * playerDir,
            wallCheckLength,
            whatIsGround);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(
            transform.position,
            new Vector2(transform.position.x, transform.position.y - groundCheckLength)
            );
        Gizmos.DrawLine(
            transform.position,
            new Vector2(transform.position.x + wallCheckLength * playerDir, transform.position.y)
            );
    }
}
