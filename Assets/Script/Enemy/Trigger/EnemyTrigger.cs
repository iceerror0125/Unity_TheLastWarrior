using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Enemy enemy;
    private HitPlayerTrigger hitPlayerTrigger;
    void Start()
    {
        hitPlayerTrigger = new HitPlayerTrigger();
        enemy = GetComponentInParent<Enemy>();  
    }
    public void HitPlayer()
    {
        hitPlayerTrigger.ActiveTrigger(enemy);
    }

   
}
