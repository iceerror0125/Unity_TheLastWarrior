using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_SkillExplain : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI skillName;
    [SerializeField] private TextMeshProUGUI type;
    [SerializeField] private TextMeshProUGUI description;

    
    public void ShowExplain(PlayerSkill _skill)
    {
        if (_skill == null)
            return;

        skillName.text = _skill.SkillName;
        description.text = _skill.Description;
        if (_skill.IsActiveSkill)
        {
            type.text = $"<color=green>Active</color>";
        }
        else
        {
            type.text = $"<color=red>Passive</color>";
        }
    }
}
