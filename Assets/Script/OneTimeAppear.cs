using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeAppear : MonoBehaviour
{
    private void Start()
    {
        int value = PlayerPrefs.GetInt(gameObject.name, 0);
        if (value == 1)
        {
            Destroy(gameObject);
        }
    }

    public void DestroyOTA()
    {
        PlayerPrefs.SetInt(gameObject.name, 1);
    }
}
