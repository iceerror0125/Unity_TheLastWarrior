using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Transform esc;
    [SerializeField] private GameObject map;
    void Start()
    {
        map.SetActive(false);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOnOff(esc);
        }
        TurnOnOffMap();
    }

    private void TurnOnOffMap()
    {
        if (Input.GetKey(KeyCode.Tab))
        {
            map.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            map.SetActive(false);
        }
    }

    public void TurnOnOff(Transform obj)
    {
        if (obj.gameObject.activeSelf)
        {
            obj.gameObject.SetActive(false);
        }
        else
        {
            obj.gameObject.SetActive(true);
        }
    }
}
