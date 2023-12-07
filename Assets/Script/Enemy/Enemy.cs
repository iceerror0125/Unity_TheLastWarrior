using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Enemy : Entity
{
    [Header("Detect player")]
    [SerializeField] protected float detectPlayerDistance;
    [SerializeField] protected Vector2 additionalDetectPosition; // outside this tranform collider
    [SerializeField] protected bool isDetected;
    [SerializeField] protected LayerMask whatIsPlayer;
    [SerializeField] protected float exitBattleStateTime;
    [Header("Attack")]
    [SerializeField] protected float attackRange;

    public void SetIsDetectedPlayer(bool _value) => isDetected = _value;
    public bool IsDetected() => isDetected;
    public float ExitBattleStateTime => exitBattleStateTime;

    protected override void Start()
    {
        base.Start();
        isFacingRight = true;
    }

    public void Flip()
    {
        isFacingRight =! isFacingRight;
        ChangeRotation();
    }

    public bool IsPlayerInAttackRange()
    {
        var collider = Physics2D.OverlapCircle(transform.position, attackRange, whatIsPlayer);
        if (collider!= null && collider.GetComponent<Player>() != null) {
            return true;
        }
        return false ;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    
}
