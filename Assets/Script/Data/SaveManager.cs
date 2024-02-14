using System;
using System.Collections;
using System.Collections.Generic;
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
        SavePlayerStat();
        SaveSkillData();
        //SaveInventoryData();
        // checkpoiint -> get scene name


        fileManager.SaveData(mainData);
    }
    public void LoadData()
    {
        mainData = fileManager.LoadData();
        LoadPlayerStat();
        LoadSkillData();
    }

    private void LoadPlayerStat()
    {
        EntityStat stat = PlayerManager.instance.player.stat;
        PlayerStatData statData = mainData.playerStatData;
        stat.SetMaxHp(statData.maxHP);
        stat.SetHP(statData.currentHP);
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
                }
            }
        }

        // dimond
        SkillManager.instance.SetDimond(mainData.dimond);

        // skill set
        int counter = 0;
        foreach(KeyValuePair<string, float> pair in mainData.skillCountdown)
        {
            PlayerSkill skill = SkillManager.instance.FindSkillByName(pair.Key);
            if (skill != null)
            {
                skill.counteddownTime = pair.Value;
                switch(counter)
                {
                    case 0: SkillManager.instance.SetA(skill); break;
                    case 1: SkillManager.instance.SetS(skill); break;
                    case 2: SkillManager.instance.SetD(skill); break;
                }
                counter++;
            }
        }
    }
    private void SaveInventoryData()
    {
        throw new NotImplementedException();
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
        //UI_SkillSet skillSet = SkillManager.instance.SkillSet;
        
        var setA = CheckSkillSet(SkillManager.instance.Slot1, "Skill A");
        SaveSkillCountdown(setA);
        var setS = CheckSkillSet(SkillManager.instance.Slot2, "Skill S");
        SaveSkillCountdown(setS);
        var setD = CheckSkillSet(SkillManager.instance.Slot3, "Skill D");
        SaveSkillCountdown(setD);
  
        
    }

    private void SaveSkillCountdown(KeyValuePair<string, float> set)
    {
        if (!mainData.skillCountdown.ContainsKey(set.Key))
        {
            mainData.skillCountdown.Add(set.Key, set.Value);
        }
        else
        {
            mainData.skillCountdown[set.Key] = set.Value;
        }
    }

    private KeyValuePair<string, float> CheckSkillSet(PlayerSkill skill, string defaultName)
    {
        if (skill is null)
            return new KeyValuePair<string, float>(defaultName, 0f);
        return new KeyValuePair<string, float>(skill.SkillName, skill.counteddownTime);
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

    public void SaveOneTimeAppear(string id)
    {
        if (!mainData.uniqueGOIdList.Contains(id))
        {
            mainData.uniqueGOIdList.Add(id);
            fileManager.SaveData(mainData);
        }
    }
}
