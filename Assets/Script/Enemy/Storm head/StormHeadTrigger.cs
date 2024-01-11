using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHeadTrigger : EnemyTrigger
{
    StormHead stormHead;
    protected override void Start()
    {
        base.Start();
        stormHead = (StormHead)enemy;
    }
    public void LeftRightAttackTrigger()
    {
        if (stormHead.isRightPoint)
        {
            stormHead.AttackCheck.transform.position = stormHead.rightPoint.position;
            stormHead.isRightPoint = false;
        }
        else
        {
            stormHead.AttackCheck.transform.position = stormHead.leftPoint.position;
            stormHead.isRightPoint = true;
        }
    }
}
