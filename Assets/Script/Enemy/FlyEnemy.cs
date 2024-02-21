using System.Text;
using System;
using UnityEngine;
using UnityEngine.UIElements;

public class FlyEnemy : Enemy
{
    [Header("Fly Setting")]
    [SerializeField] protected Vector2 limitBoxSize;
    private Vector2 originalPosition;
    private FieldOfView fov;

    protected override void Start()
    {
        base.Start();
        originalPosition = transform.position;
        rb.gravityScale = 0;
        fov = GetComponentInChildren<FieldOfView>();
    }
    protected override void Update()
    {
        base.Update();
        if (DetectPlayer() && isDetected == false && !PlayerManager.instance.player.IsDead)
        {
            stateMachine.ChangeState(battleState);
        }
    }

    public bool IsInsideFlyBox(Vector2 current)
    {
        Vector2 minLimit = originalPosition - limitBoxSize / 2f;
        Vector2 maxLimit = originalPosition + limitBoxSize / 2f;

        if (current.x > minLimit.x && current.x < maxLimit.x &&
            current.y > minLimit.y && current.y < maxLimit.y)
        {
            return true;
        }
        return false;
    }
    public void BackToFLyBox()
    {
        transform.position = Vector2.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime); 
    }
    public bool isInOriginalPos()
    {
        BackToFLyBox();
        if ((Vector2)transform.position == originalPosition)
        {
            return true;
        }
        return false;
    }
   
    public bool DetectPlayer()
    {
        var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir, transform.position.y);
        fov.origin = detectPosition;
        fov.viewDistance = detectPlayerDistance;
        fov.target = whatIsPlayer;
        return fov.DetectObject();


    }
    /* private Vector2 RayCastAngleVector(float angle)
     {
         var detectPosition = new Vector2(transform.position.x + additionalDetectPosition.x * EntityDir, transform.position.y);

         float angleInRadians = angle * Mathf.Deg2Rad;
         Vector2 raycastDirection = new Vector2(Mathf.Cos(angleInRadians) * entityDir, Mathf.Sin(angleInRadians));
         Debug.DrawRay(detectPosition, raycastDirection * detectPlayerDistance, Color.red);
         return raycastDirection;
     }
     bool DetectPlayer(Vector2 origin, Vector2 direction, float distance)
     {
         RaycastHit2D hit = Physics2D.Raycast(origin, direction, distance);
         Debug.Log(hit.collider.gameObject.layer);
         if (hit.collider != null && hit.collider.gameObject.layer == 6)
         {
             return true;
         }

         return false;
     }*/

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectPlayerDistance);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(originalPosition, limitBoxSize);
    }
}
