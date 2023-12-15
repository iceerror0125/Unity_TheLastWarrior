using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff2 : PlayerSkill
{
    private float plusDamage;
    protected override void SetUp()
    {
        // +50% damage
        plusDamage = player.stat.Damage + player.stat.Damage * 0.5f;
        player.stat.SetDamage(plusDamage);
    }
}
