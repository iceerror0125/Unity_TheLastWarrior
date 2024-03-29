using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [SerializeField] private PlayerSkill slot1;
    [SerializeField] private PlayerSkill slot2;
    [SerializeField] private PlayerSkill slot3;
    [SerializeField] private GameObject skillTree;
    [SerializeField] private UI_SkillSet skillSet;

    [SerializeField] private List<PlayerSkill> skillList;
    public int dimond { get; private set; }
    public System.Action UpdateDimondUI = () => { };

    public PlayerSkill Slot1 => slot1;
    public PlayerSkill Slot2 => slot2;
    public PlayerSkill Slot3 => slot3;
    public List<PlayerSkill> SkillList => skillList;
    public UI_SkillSet SkillSet => skillSet;
    public void SetDimond(int dimond) => this.dimond = dimond;
    public void PlusDimond()
    {
        dimond++;
        UpdateDimondUI();
    }
    public void MinusDimond()
    {
        dimond--;
        if (dimond < 0)
        {
            dimond = 0;
        }
        UpdateDimondUI();

    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
        slot1 = null;
        slot2 = null;
        slot3 = null;
    }

    private void Update()
    {
        if (skillTree.activeSelf || GameManager.Instance.isUITurnedOn)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            slot1?.Activate();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slot2?.Activate();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slot3?.Activate();
        }
    }

    /*public void SetSkillSlot(PlayerSkill _slot1 = null, PlayerSkill _slot2 = null, PlayerSkill _slot3 = null)
    {
        CheckExistedSkill();
        slot1 = _slot1 != null ? _slot1 : slot1;
        slot2 = _slot2 != null ? _slot2 : slot2;
        slot3 = _slot3 != null ? _slot3 : slot3;
    }*/

    public void SetA(PlayerSkill _skill)
    {
        CheckExistedSkill(_skill);
        slot1 = _skill;
        UpdateSkillSet();
    }
    public void SetS(PlayerSkill _skill)
    {
        CheckExistedSkill(_skill);
        slot2 = _skill;
        UpdateSkillSet();
    }
    public void SetD(PlayerSkill _skill)
    {
        CheckExistedSkill(_skill);
        slot3 = _skill;
        UpdateSkillSet();
    }

    private void CheckExistedSkill(PlayerSkill _skill)
    {
        if (slot1 == _skill) slot1 = null;
        if (slot2 == _skill) slot2 = null;
        if (slot3 == _skill) slot3 = null;
    }
    private void UpdateSkillSet()
    {
        skillSet.SetA(slot1);
        skillSet.SetS(slot2);
        skillSet.SetD(slot3);
    }
    public PlayerSkill FindSkillByName(string name)
    {
        for (int i = 0; i < skillList.Count; i++)
        {
            if (skillList[i].SkillName.Equals(name)) 
                return skillList[i];
        }
        return null;
    }
}
