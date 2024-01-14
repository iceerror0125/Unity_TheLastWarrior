using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillBarManagement : MonoBehaviour
{
    [SerializeField] private UI_SkillBarSlot slot1;
    [SerializeField] private UI_SkillBarSlot slot2;
    [SerializeField] private UI_SkillBarSlot slot3;
    [SerializeField] private UI_SkillBarSlot slot4;

    private SkillManager manager;
    private void Start()
    {
        manager = SkillManager.instance;
    }

    private void Update()
    {
        slot1.SetUpSlot(manager.Slot1);
        slot2.SetUpSlot(manager.Slot2);
        slot3.SetUpSlot(manager.Slot3);
    }

}
