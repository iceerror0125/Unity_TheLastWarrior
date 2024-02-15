using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeAppearManager : MonoBehaviour
{
    public static OneTimeAppearManager instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance.gameObject);
        DontDestroyOnLoad(this);
    }

    public void CheckDestroyAppear()
    {
        //string[] allKeys = PlayerPrefs.GetAllKeys();

    }
    public void SaveToPlayerPref(string key)
    {
        PlayerPrefs.SetInt(key, 1);
    }
}
