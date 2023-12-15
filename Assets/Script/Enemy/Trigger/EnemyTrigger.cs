using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    private Enemy enemy;
    private HitPlayerTrigger hitPlayerTrigger;
    private CancelAttackTrigger cancelAttackTrigger;
    private DestroyObjectTrigger destroyObjectTrigger;
    void Start()
    {
        hitPlayerTrigger = new HitPlayerTrigger();
        cancelAttackTrigger = new CancelAttackTrigger();
        destroyObjectTrigger = new DestroyObjectTrigger();

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

    public void DestroyGameObjectTrigger()
    {
        destroyObjectTrigger.ActiveTrigger(enemy);
    }

}
