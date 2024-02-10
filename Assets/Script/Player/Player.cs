using UnityEngine;

public class Player : Entity
{
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
    public PlayerHurtState hurtState { get; private set; }
    #endregion

    #region Player setting

    [Header("Wall Slide")]
    [SerializeField] private float wallSlideGravity;
    [SerializeField] private float wallSlideJumpForce;
    [SerializeField] private bool isSliding;
    public Transform exitWallState;


    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private int jumpCounter;
    [SerializeField] private bool canHighJump;
    [SerializeField] private float moveSpeedInAir;

    [Header("Fall")]
    [SerializeField] private float fallGravity;
    [SerializeField] private float defaultGravity;
    [SerializeField] private bool isFirstAttack;

    public float timer;
    public CameraFollowPlayer camFollow;
    public bool isJumping;
    #endregion

    #region Getter Setter
    public float JumpForce => jumpForce;
    public float MoveSpeedInAir => moveSpeedInAir;
    public bool IsFirstAttack => isFirstAttack;
    public int JumpCounter => jumpCounter;
    public void ZeroJumpCounter() => jumpCounter = 0;
    public void PlusJumpCounter() => jumpCounter++;
    public bool CanHighJump => canHighJump;
    public void SetCanHighJump(bool _canHighJump) => canHighJump = _canHighJump;
    public void SetIsFirstAttack(bool _isFirstAttack) => isFirstAttack = _isFirstAttack;
    public float WallSlideJumpForce => wallSlideJumpForce;
    public bool IsSliding => isSliding;
    public void SetIsSliding(bool _value) => isSliding = _value;
    public float WallSlideGravity => wallSlideGravity;
    // public PlayerStat PlayerStat => stat;
    #endregion

    protected override void Start()
    {
        base.Start();
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
        hurtState = new PlayerHurtState("Player_Hurt");
        #endregion

        stateMachine.InitState(idleState);

        isFacingRight = true;
        jumpCounter = 0;
        canHighJump = true;
    }
    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;
        if (GameManager.Instance.isCutScene || GameManager.Instance.isUITurnedOn)
            return;

        moveDir = Input.GetAxisRaw("Horizontal");
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

    /* public override void KnockBack(Entity attacker, float x, float y)
     {
         base.KnockBack(attacker, x, y);
         stateMachine.ChangeState(hurtState);
     }*/
    public override void KnockBack(Entity attacker, Vector2 knockback)
    {
        base.KnockBack(attacker, knockback);
        stateMachine.ChangeState(hurtState);
    }

    public Enemy NeareastEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 10f);
        foreach (var collider in colliders)
        {
            if (collider.GetComponent<Enemy>() != null)
            {
                return collider.GetComponent<Enemy>();
            }
        }
        return null;
    }

    public override void ChangeRotation()
    {
        base.ChangeRotation();
        camFollow.RotateCamera();
    }


    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawWireSphere(exitWallState.position, 1);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.layer == 3 && !isGround && !isDead)
        {
            stateMachine.ChangeState(fallState);
        }
    }
}
