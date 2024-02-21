using Unity.Burst.CompilerServices;
using UnityEngine;

public class GroundEnemy : Enemy
{
    protected float raycastAngle = 15f;
    protected override void Start()
    {
        base.Start();
        rb.gravityScale = 4f;
    }
    protected override void Update()
    {
        base.Update();
        if (DetectPlayer() && isDetected == false && !PlayerManager.instance.player.IsDead)
        {
            stateMachine.ChangeState(battleState);
        }
    }
    public bool DetectPlayer()
    {
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir, transform.position.y);
        var hit = DetectPlayer(detectPosition, Vector2.right * EntityDir, detectPlayerDistance);
        var angleHit = DetectPlayer(detectPosition, RayCastAngleVector(), detectPlayerDistance + 1);
        return hit || angleHit;
    }
    private Vector2 RayCastAngleVector()
    {
        float angleInRadians = raycastAngle * Mathf.Deg2Rad;
        Vector2 raycastDirection = new Vector2(Mathf.Cos(angleInRadians) * entityDir, Mathf.Sin(angleInRadians));
        Debug.DrawRay(transform.position, raycastDirection * detectPlayerDistance, Color.red);
        return raycastDirection;
        //return Physics2D.Raycast(transform.position, raycastDirection, detectPlayerDistance + 2);
    }

    bool DetectPlayer(Vector2 origin, Vector2 direction, float distance)
    {
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.layer == 6)
            {
                return true;
            }
        }
        
        return false;
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir, transform.position.y);
        Gizmos.DrawLine(detectPosition, new Vector2(detectPosition.x + detectPlayerDistance * EntityDir, detectPosition.y));
    }
}
