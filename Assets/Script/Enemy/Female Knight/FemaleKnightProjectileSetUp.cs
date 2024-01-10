using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleKnightProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float rad;
    [SerializeField] private float speed;
    [SerializeField] private float length;
    [SerializeField] private Vector2 origin;
    [SerializeField] private Vector2 target;
    private FemaleKnight fk;
    private bool isHit;
    private bool goForward;

    void Start()
    {
        origin = fk.transform.position;
        target = new Vector2(origin.x + length * fk.EntityDir, origin.y);
        isHit = false;
        goForward = true;
    }

    public void Activate(FemaleKnight fk)
    {
        this.fk = fk;
        Start();
        Update();
    }

    void Update()
    {
        origin = fk.transform.position;

        if (goForward)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, origin, speed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target) < 0.1f)
        {
            isHit = false;
            goForward = false;
        }
       

        HitController();
    }

    public void HitController()
    {
        var collider = Physics2D.OverlapCircle(transform.position, rad);
        if (collider == null)
            return;

        FemaleKnight knight = collider.GetComponent<FemaleKnight>();
        Player player = collider.GetComponent<Player>();
        if (player != null)
        {
            if (!isHit)
            {
                fk.CauseDamage(player);
                isHit = true;
            }
        }
        if (knight != null)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
