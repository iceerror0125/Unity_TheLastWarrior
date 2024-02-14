using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class PlayerStatData 
{
    public float maxHP;
    public float currentHP;
    public float dmg;
    public float critRate;
    public float critDamage;
    public PlayerStatData() { }
    public PlayerStatData (EntityStat stat)
    {
        this.maxHP = stat.MaxHp;
        this.currentHP = stat.Hp;
        this.dmg = stat.Damage;
        this.critRate = stat.CritRate;
        this.critDamage = stat.CritDamage;
    }
}
