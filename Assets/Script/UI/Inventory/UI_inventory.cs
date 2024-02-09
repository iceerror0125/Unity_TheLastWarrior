using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    [SerializeField] private GameObject skillTree;

    void Update()
    {
        if (HUDManager.instance.IsESCMenuOn())
            return;

        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
            }
            else
            {
                inventory.SetActive(true);
                skillTree.SetActive(false);
                inventory.GetComponent<UI_InventoryCursorController>().InitCursor();
                AudioManager.instance.environment.InventoryOpen();

            }

            UI_PlayerStat.instance.UpdateStat();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            if (skillTree.activeSelf)
            {
                skillTree.SetActive(false);
            }
            else
            {
                skillTree.SetActive(true);
                inventory.SetActive(false);
                skillTree.GetComponent<UI_SkillTreeCursorController>().InitCursor();
                AudioManager.instance.environment.InventoryOpen();
            }
        }
    }
}
