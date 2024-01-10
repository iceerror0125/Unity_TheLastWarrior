using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeadTrigger : EnemyTrigger
{
    BringerOfDeath bod;
    protected override void Start()
    {
        base.Start();
        bod = (BringerOfDeath)enemy;
    }

    public void AppearTrigger()
    {
        if (bod.isReverse)
        {
            bod.SetIsAppear(true);
        }
    }

}
