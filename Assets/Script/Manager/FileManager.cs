using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class FileManager
{
    private string dir = Application.persistentDataPath;
    private string tempFileName = "temp.json";
    private string mainFileName = "data.json";
    public void LoadGame()
    {
        // load entire game data from file
        // call this method when use "Continue" or respawn player
    }
    public void SaveAtCheckpoint()
    {
        // Save entire game data
        // - break wall
        // - some object trigger
        // - inventory
        // - player stat
    }
    public void SaveSkillTree()
    {
        // call this method when unlock new skill
        // - save skill unlock
        // - save dimond
    }
    public void SaveData(GameData data)
    {
        string fullPath = Path.Combine(dir, mainFileName);
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

    }
    public GameData LoadData()
    {
        string fullPath = Path.Combine(dir, mainFileName);
        GameData loadData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                string stringData = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        stringData = reader.ReadToEnd();
                    }
                }
                loadData = JsonUtility.FromJson<GameData>(stringData);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
        return loadData;
    }
    public bool ExistsFileSave()
    {
        string fullPath = Path.Combine(dir, mainFileName);
        return File.Exists(fullPath);
    }
}
