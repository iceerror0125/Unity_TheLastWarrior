using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

[RequireComponent(typeof(EnemyStat))]
public class Enemy : Entity
{
    #region Enemy Setting
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

    //public EnemyStat stat { get; private set; }


    #region Get Set

    public void SetIsDetectedPlayer(bool _value) => isDetected = _value;
    public bool IsDetected() => isDetected;
    public float ExitBattleStateTime => exitBattleStateTime;
    public bool IsAttack => isAttack;
    public void SetIsAttack(bool _value) => isAttack = _value;
    #endregion

    protected override void Start()
    {
        base.Start();
        //stat = GetComponent<EnemyStat>();
        isFacingRight = true;
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


}
