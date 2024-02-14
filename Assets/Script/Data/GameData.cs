using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string checkPointScene;
    public List<string> uniqueGOIdList;
    public PlayerStatData playerStatData;
    public SerializableDictionary<string, bool> skillTree;
    public SerializableDictionary<string, float> skillCountdown;

    public int dimond;
    public string equipId;
    public List<string> stashIdList;

    public GameData() { 
        checkPointScene = string.Empty;
        uniqueGOIdList = new List<string>();
        playerStatData = new PlayerStatData();
        skillTree = new SerializableDictionary<string, bool>();
        skillCountdown = new SerializableDictionary<string, float>();
        dimond = -1;
        equipId = string.Empty;
        stashIdList = new List<string>();
    }

}
