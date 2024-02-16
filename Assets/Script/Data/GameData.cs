using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string checkPointScene;
    public PlayerStatData playerStatData;
    public SerializableDictionary<string, bool> skillTree;
    public string[] skilSetName;
    public float[] skillSetCountdown;

    public int dimond;
    public string equipId;
    public List<string> stashIdList;

    public GameData() { 
        checkPointScene = string.Empty;
        playerStatData = new PlayerStatData();
        skillTree = new SerializableDictionary<string, bool>();
        skilSetName = new string[3];
        skillSetCountdown = new float[3];
        dimond = -1;
        equipId = string.Empty;
        stashIdList = new List<string>();
    }

}
