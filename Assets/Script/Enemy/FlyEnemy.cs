using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEnemy : Enemy
{
    [Header("Move")]
    [SerializeField] private Vector2 moveRange;
    public Vector2 MoveRange => moveRange;
    public bool DetectPlayer()
    {
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir(), transform.position.y);
        var colliders = Physics2D.OverlapCircleAll(detectPosition, detectPlayerDistance);
        if (colliders != null)
        {
            foreach(var collider in colliders)
            {
                LayerMask hitLayer = 1 << collider.gameObject.layer;
                if (hitLayer == whatIsPlayer)
                    return true;
            }
        }

        return false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectPlayerDistance);
    }
}
