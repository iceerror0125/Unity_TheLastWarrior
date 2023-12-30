using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Enemy
{
    public bool DetectPlayer()
    {
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir(), transform.position.y);
        var hit = Physics2D.Raycast(detectPosition, Vector2.right * EntityDir(), detectPlayerDistance);
        if (hit.collider != null)
        {
            LayerMask hitLayer = 1 << hit.collider.gameObject.layer;
            if (hitLayer == whatIsPlayer)
                return true;
        }
        
        return false;
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir(), transform.position.y);
        Gizmos.DrawLine(detectPosition, new Vector2(detectPosition.x + detectPlayerDistance * EntityDir(), detectPosition.y));
    }
}
