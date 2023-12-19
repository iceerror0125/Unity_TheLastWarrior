using AYellowpaper.SerializedCollections;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public List<ItemData> stashList;
    public Dictionary<ItemData, InventoryItem> stashDic;
    public ItemDataEquipment equipSlot;

    public Transform stashSlotParent;
    public UI_SlotItem[] uiStashSlots;

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

        stashList = new List<ItemData>();
        stashDic = new Dictionary<ItemData, InventoryItem>();
    }

    private void Start()
    {
        uiStashSlots = stashSlotParent.GetComponentsInChildren<UI_SlotItem>();

        ClearUI();
    }

    private void UpdateUI()
    {
        ClearUI();
        for (int i = 0; i < stashList.Count; i++)
        {
            uiStashSlots[i].SetupImageSlot(stashList[i]);
        }

        UI_PlayerStat.instance.UpdateStat();
    }

    private void ClearUI()
    {
        for (int i = 0; i < uiStashSlots.Length; i++)
        {
            uiStashSlots[i].ClearSlot();
        }
    }

    public void AddItem(ItemData item)
    {
        // already exist
        if (stashDic.TryGetValue(item, out var value))
        {
            value.Plus();
        }
        // add new one
        else
        {
            InventoryItem newItem = new InventoryItem(item);
            stashList.Add(item);
            stashDic.Add(item, newItem);
        }
        UpdateUI();
    }
    public void AddEquipmentItem(ItemDataEquipment item)
    {
        // already exist, automaticly add to stash and add to equip slot
        if (equipSlot != null)
        {
            AddItem(equipSlot);
        }
        equipSlot = item;
    }

    public void RemoveItem(ItemData item)
    {
        if (stashDic.TryGetValue(item, out var value))
        {
            if (value.Amount > 1)
            {
                value.Decrease();
            }
            else
            {
                stashList.Remove(item);
                stashDic.Remove(item);
            }
        }
        UpdateUI();
    }

    public void RemoveEquipment(ItemDataEquipment item)
    {
        if (equipSlot != null)
        {
            equipSlot = null;
            AddItem(item);
        }
    }
}
