using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadSkill1SetUp : MonoBehaviour
{
    StormHead sh;

    [SerializeField] private Vector2 size;
    public void Activate(StormHead sh)
    {
        this.sh = sh;
        Start();
        Update();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void HitPlayer()
    {
        var raycasts = Physics2D.BoxCastAll(transform.position, size, 0, Vector2.zero);
        if (raycasts != null)
        {
            foreach (var raycast in raycasts)
            {
                Player player = raycast.collider.GetComponent<Player>();
                if (player != null)
                {
                    sh.CauseDamage(player);
                }
            }
            
        }
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, size);
    }
}
