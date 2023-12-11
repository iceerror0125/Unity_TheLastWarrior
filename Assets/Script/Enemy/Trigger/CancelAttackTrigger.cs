using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelAttackTrigger 
{
    public void ActiveTrigger(Enemy enemy)
    {
        enemy.SetIsAttack(false);
    }
}
