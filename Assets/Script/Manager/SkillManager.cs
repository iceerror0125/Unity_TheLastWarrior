using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [SerializeField] private PlayerSkill slot1;
    [SerializeField] private PlayerSkill slot2;
    [SerializeField] private PlayerSkill slot3;
    [SerializeField] private GameObject skillTree;
    [SerializeField] private UI_SkillSet skillSet;
    public PlayerSkill Slot1 => slot1;
    public PlayerSkill Slot2 => slot2;
    public PlayerSkill Slot3 => slot3;

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
    }

    private void Update()
    {
        if (skillTree.activeSelf)
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
        skillSet.SetA(slot1?.Img);
        skillSet.SetS(slot2?.Img);
        skillSet.SetD(slot3?.Img);
    }
}
