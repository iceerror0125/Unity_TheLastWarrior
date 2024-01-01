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

    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool canDoubleJump;
    [SerializeField] private bool canHighJump;
    [SerializeField] private float moveSpeedInAir;

    [Header("Fall")]
    [SerializeField] private float fallGravity;
    [SerializeField] private float defaultGravity;
    [SerializeField] private bool isFirstAttack;

    public float timer;
    #endregion

    #region Getter Setter
    public float JumpForce => jumpForce;
    public float MoveSpeedInAir => moveSpeedInAir;
    public bool IsFirstAttack => isFirstAttack;
    public bool CanDoubleJump => canDoubleJump;
    public void SetCanDoubleJump(bool _canDoubleJump) => canDoubleJump = _canDoubleJump;
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
        canDoubleJump = true;
        canHighJump = true;
    }
    protected override void Update()
    {
        base.Update();
        timer -= Time.deltaTime;

        moveDir = Input.GetAxisRaw("Horizontal");

        if (isDead)
        {
            stateMachine.ChangeState(deadState);
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

    /*public override void KnockBack(Entity _attacker, float x, float y)
    {
        base.KnockBack(_attacker, x, y);
        stateMachine.ChangeState(hurtState);
    }

    public void SpellHitFarKnockBack(Entity _hitEntity, float _damage)
    {
        _hitEntity.KnockBack(this, 30, 4);
        PerformSpellAttack(_hitEntity, _damage);
    }
    public void SpellHit(Entity _hitEntity, float _damage)
    {
        _hitEntity.KnockBack(this, 4, 4);
        PerformSpellAttack(_hitEntity, _damage);
    }*/

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
}
