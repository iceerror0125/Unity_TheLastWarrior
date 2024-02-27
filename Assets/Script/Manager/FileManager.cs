using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


public class FileManager
{
    private string dir = Application.persistentDataPath;
    private string mainFileName = "data.json";

    public void SaveData(GameData data)
    {
        string fullPath = Path.Combine(dir, mainFileName);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));
            string dataStore = JsonUtility.ToJson(data, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    dataStore = EncodeStringData(dataStore);
                    writer.Write(dataStore);
                }
            }
           /* using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                formatter.Serialize(stream, data);
            }*/

        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }

    }
    public GameData LoadData()
    {
        string fullPath = Path.Combine(dir, mainFileName);
        BinaryFormatter formatter = new BinaryFormatter();

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
                        stringData = DecodeStringData(stringData);
                       /* stream.Seek(0, SeekOrigin.Begin);
                        stringData = formatter.Deserialize(stream) as string;
                        Debug.Log(stringData);*/
                    }
                    /*stringData = formatter.Deserialize(stream) as string;
                    Debug.Log(stringData);*/
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
    public void DeleteData()
    {
        string fullPath = Path.Combine(dir, mainFileName);
        if (ExistsFileSave())
        {
            File.Delete(fullPath);
        }
    }

    private string EncodeStringData(string data)
    {
        char[] charArray = data.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            charArray[i] = Encode(charArray[i]);
        }
        return new string(charArray);
    }
    private string DecodeStringData(string data)
    {
        char[] charArray = data.ToCharArray();
        for (int i = 0; i < charArray.Length; i++)
        {
            charArray[i] = Decode(charArray[i]);
        }
        return new string(charArray);
    }
    private char Encode(char x)
    {
        return (char) (x << 1);
    }
    private char Decode(char x)
    {
        return (char)(x >> 1);
    }
}
