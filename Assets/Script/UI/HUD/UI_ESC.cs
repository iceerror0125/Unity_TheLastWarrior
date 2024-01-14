using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ESC : MonoBehaviour
{
    [SerializeField] Transform slot;
    [SerializeField] Transform cursor;

    private UI_ESCSlot script;
    private Transform initSlot;
    private bool isDisable;

    void Start()
    {
        initSlot = slot;
        isDisable = false;
        cursor.gameObject.SetActive(true);
        SetPosition(slot);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (script.Up != null)
            {
                SetPosition(script.Up);
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (script.Down != null)
            {
                SetPosition(script.Down);
            }
        }
    }

    private void SetPosition(Transform newSlot)
    {
        slot = newSlot;
        cursor.SetParent(newSlot);
        RectTransform rect = cursor.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
        script = slot.GetComponent<UI_ESCSlot>();   
    }

    private void OnEnable()
    {
        if (isDisable)
        {
            slot = initSlot;
            SetPosition(slot);
            isDisable = false;
        }
    }
    private void OnDisable()
    {
        isDisable = true;
    }
}
