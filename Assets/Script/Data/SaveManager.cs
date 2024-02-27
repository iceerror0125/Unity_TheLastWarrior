using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public GameData mainData { get; private set; }

    private FileManager fileManager;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else Destroy(instance.gameObject);

        fileManager = new FileManager();
        mainData = new GameData();

        // load main data here
    }

    public void SaveData()
    {
        SaveSkillData();
        SaveInventoryData();
        SavePlayerStat();
        // checkpoiint -> get scene name


        fileManager.SaveData(mainData);
    }
    public void LoadData()
    {
        mainData = fileManager.LoadData();
        LoadPlayerStat();
        LoadSkillData();
        LoadInventoryData();
    }

    private void LoadPlayerStat()
    {
        EntityStat stat = PlayerManager.instance.player.stat;
        PlayerStatData statData = mainData.playerStatData;
        stat.SetMaxHp(statData.maxHP);
        if (statData.currentHP <= 0)
        {
            stat.SetHP(statData.maxHP);
        }
        else
        {
            stat.SetHP(statData.currentHP);
        }

        stat.SetDamage(statData.dmg);
        stat.SetCritRate(statData.critRate);
        stat.SetCritDamage(statData.critDamage);
    }
    private void LoadSkillData()
    {
        // skill tree
        foreach (KeyValuePair<string, bool> data in mainData.skillTree)
        {
            for (int i = 0; i < SkillManager.instance.SkillList.Count; i++)
            {
                PlayerSkill skill = SkillManager.instance.SkillList[i];
                if (data.Key.Equals(skill.SkillName))
                {
                    skill.Unlock(data.Value);
                    if (data.Value && !skill.IsActiveSkill)
                    {
                        skill.Activate();
                    }
                }
            }
        }
        // dimond
        SkillManager.instance.SetDimond(mainData.dimond);
        // skill set
        LoadSkillSetData();
    }

    private void LoadSkillSetData()
    {
        if (mainData.skilSetName.Length != mainData.skillSetCountdown.Length)
        {
            Debug.Log("Lenght Array Is Not Match");
            return;
        }

        SkillManager manager = SkillManager.instance;
        manager.SetA(manager.FindSkillByName(mainData.skilSetName[0]));
        manager.SetS(manager.FindSkillByName(mainData.skilSetName[1]));
        manager.SetD(manager.FindSkillByName(mainData.skilSetName[2]));

        if (manager.Slot1 != null)
        {
            manager.Slot1.counteddownTime = mainData.skillSetCountdown[0];
        }
        if (manager.Slot2 != null)
        {
            manager.Slot2.counteddownTime = mainData.skillSetCountdown[1];
        }
        if (manager.Slot3 != null)
        {
            manager.Slot3.counteddownTime = mainData.skillSetCountdown[2];
        }
    }

    private void LoadInventoryData()
    {
        Inventory inventory = Inventory.instance;
        // equip
        ItemDataEquipment equip = FindItemDataPrefab(mainData.equipId) as ItemDataEquipment;
        if (equip != null)
        {
            inventory.AddEquipmentItem(equip);
        }

        // stash
        for (int i = 0; i < mainData.stashIdList.Count; i++)
        {
            ItemData item = FindItemDataPrefab(mainData.stashIdList[i]);
            int amount = mainData.stashVolume[mainData.stashIdList[i]];
            if (item != null)
            {
                inventory.SetItem(item, amount);
                //inventory.AddItem(item);
            }
        }
    }

    private void SaveInventoryData()
    {
        Inventory inventory = Inventory.instance;
        mainData.equipId = "";
        if (inventory.equipSlot != null)
        {
            mainData.equipId = inventory.equipSlot.id;
            //minus stat item
            inventory.MinusPlayerStat(inventory.equipSlot);
        }

        //stash 
        mainData.stashIdList.Clear();
        mainData.stashVolume.Clear();
        for (int i = 0; i < inventory.stashList.Count; i++)
        {
            string id = inventory.stashList[i].id;
            mainData.stashIdList.Add(id);

            // volume
            int amount = inventory.stashDic[inventory.stashList[i]].Amount;
            mainData.stashVolume.Add(id, amount);
        }
    }

    private void SaveSkillData()
    {
        // skill tree
        for (int i = 0; i < SkillManager.instance.SkillList.Count; i++)
        {
            PlayerSkill skill = SkillManager.instance.SkillList[i];
            if (mainData.skillTree.TryGetValue(skill.SkillName, out var data))
            {
                mainData.skillTree[skill.SkillName] = skill.IsUnlock;
            }
            else
            {
                mainData.skillTree.Add(skill.SkillName, skill.IsUnlock);
            }
        }

        // save dimond
        mainData.dimond = SkillManager.instance.dimond;

        // skill set
        SaveSkillSet(0, SkillManager.instance.Slot1, "Skill A");
        SaveSkillSet(1, SkillManager.instance.Slot2, "Skill S");
        SaveSkillSet(2, SkillManager.instance.Slot3, "Skill D");
    }

    private void SaveSkillSet(int index, PlayerSkill skill, string defaultName)
    {
        if (index < 3)
        {
            if (skill is null)
            {
                mainData.skilSetName[index] = defaultName;
                mainData.skillSetCountdown[index] = -1;
            }
            else
            {
                mainData.skilSetName[index] = skill.SkillName;
                mainData.skillSetCountdown[index] = skill.counteddownTime;
            }
        }
    }

    private void SavePlayerStat()
    {
        EntityStat stat = PlayerManager.instance.player.stat;
        PlayerStatData statData = new PlayerStatData(stat);

        mainData.playerStatData = statData;
    }

    public bool ExistsFileSave()
    {
        return fileManager.ExistsFileSave();
    }

    public void DeleteFileSave()
    {
        fileManager.DeleteData();
    }

    private ItemData FindItemDataPrefab(string id)
    {
        ItemData[] items = Resources.LoadAll<ItemData>("Items");
        foreach (var item in items)
        {
            if (item != null && item.id == id)
            {
                return item;
            }
        }
/*#if UNITY_EDITOR
        string[] assets = AssetDatabase.FindAssets("", new[] { "Assets/Items" });
        foreach (string asset in assets)
        {
            var SOPath = AssetDatabase.GUIDToAssetPath(asset);
            var itemData = AssetDatabase.LoadAssetAtPath<ItemData>(SOPath);
            if (itemData != null && itemData.id == id)
            {
                return itemData;
            }
        }
#else
    string path = "Assets/Items/" + id;
    ItemData itemData = Resources.Load<ItemData>(path);
    return itemData;
#endif*/
        return null;
    }

}
