using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    [SerializeField] private PlayerSkill slot1;
    [SerializeField] private PlayerSkill slot2;
    [SerializeField] private PlayerSkill slot3;

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
        if (Input.GetKeyDown(KeyCode.A))
        {
            slot1.Activate();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            slot2.Activate();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            slot3.Activate();
        }
    }

    public void SetSkillSlot(PlayerSkill _slot1 = null, PlayerSkill _slot2 = null, PlayerSkill _slot3 = null)
    {
        slot1 = _slot1;
        slot2 = _slot2;
        slot3 = _slot3;
    }
}
