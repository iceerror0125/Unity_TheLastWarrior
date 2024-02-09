

using UnityEngine;

public class Heal3 : PlayerSkill
{
    protected override void SetUp()
    {
        base.SetUp();
        float recoverHP = player.stat.MaxHp * 0.5f;
        player.RecoverHP(recoverHP);
    }
}
