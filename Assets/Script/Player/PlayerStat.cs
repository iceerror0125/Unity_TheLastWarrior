using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : EntityStat
{
    public override void TakeDamage(float damage, bool isDeadZone = false)
    {
        base.TakeDamage(damage, isDeadZone);
        onChangeHP(damage);
        CameraManager.instance.ShakeCamera(0.3f, 3);
    }
    protected override void CanRespawn()
    {
        base.CanRespawn();
        Heal3 skill = FindRespawnSkill() as Heal3;
        if (skill != null)
        {
            hasRespawn = true;
            skill.Activate();
        }

    }

    private PlayerSkill FindRespawnSkill()
    {
        UI_SkillBarManagement manager = UI_SkillBarManagement.instance;
        //Debug.Log(manager.Slot1.Skill);
        if (manager.Slot1.Skill?.SkillName == "Respawn")
        {
            if (manager.Slot1.Skill.CanUseSkill)
                return manager.Slot1.Skill;
        }
        if (manager.Slot2.Skill?.SkillName == "Respawn")
        {
            if (manager.Slot2.Skill.CanUseSkill)
                return manager.Slot2.Skill;
        }
        if (manager.Slot3.Skill?.SkillName == "Respawn")
        {
            if (manager.Slot3.Skill.CanUseSkill)
                return manager.Slot3.Skill;
        }
        return null;
    }

    public override void ShowDeadUI()
    {
        base.ShowDeadUI();
        HUDManager.instance.ShowDeadUI();
    }
}
