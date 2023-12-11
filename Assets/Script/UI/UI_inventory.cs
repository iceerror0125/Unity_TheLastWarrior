using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_inventory : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) {
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
            }
            else
            {
                inventory.SetActive(true);
            }
        }
    }
}
