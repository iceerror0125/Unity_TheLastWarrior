using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : EntityStat
{
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        onChangeHP(damage);
    }
}
