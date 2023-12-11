using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Enemy enemy;
    private HitPlayerTrigger hitPlayerTrigger;
    private CancelAttackTrigger cancelAttackTrigger;
    void Start()
    {
        hitPlayerTrigger = new HitPlayerTrigger();
        cancelAttackTrigger = new CancelAttackTrigger();
        enemy = GetComponentInParent<Enemy>();  
    }
    public void HitPlayer()
    {
        hitPlayerTrigger.ActiveTrigger(enemy);
    }
    public void CancelAttack()
    {
        cancelAttackTrigger.ActiveTrigger(enemy);
    }

   
}
