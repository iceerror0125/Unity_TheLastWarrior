using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;
    [SerializeField] private Transform esc;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject deadUI;
    private UI_HPBar hpBar;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(instance.gameObject);
    }
    void Start()
    {
        map.SetActive(false);
        hpBar = FindObjectOfType<UI_HPBar>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!esc.gameObject.activeSelf)
            {
                esc.gameObject.SetActive(true);
                GameManager.Instance.PauseGame();
            }

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

    public void UpdateHpBar()
    {
        hpBar.UpdateHP();
    }

    public void ShowDeadUI()
    {
        deadUI.SetActive(true);
    }

    public bool IsESCMenuOn()
    {
        if (esc.gameObject.activeSelf)
            return true;
        return false;
    }
}
