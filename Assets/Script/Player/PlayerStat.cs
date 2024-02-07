using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : EntityStat
{
    public override void TakeDamage(float _damage)
    {
        base.TakeDamage(_damage);
        onChangeHP(_damage);
    }
    public override void ShowDeadUI()
    {
        base.ShowDeadUI();
        HUDManager.instance.ShowDeadUI();
    }
}
