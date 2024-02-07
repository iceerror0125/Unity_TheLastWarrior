using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_ESC : MonoBehaviour
{
    [SerializeField] Transform slot;
    [SerializeField] Transform cursor;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject skilTree;


    private UI_ESCSlot script;
    private Transform initSlot;
    private bool isDisable;
    public Stack<GameObject> displayStack { get; private set; }

    void Start()
    {
        displayStack = new Stack<GameObject>();

        initSlot = slot;
        isDisable = false;
        cursor.gameObject.SetActive(true);
        SetPosition(slot);
        displayStack.Push(slot.parent.gameObject);
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
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Return))
        {
            switch (slot.name)
            {
                case "Setting":
                    GoToDetailSelection("Audio Setting"); break;
                case "Tutorial": GoToDetailSelection("Tutorial"); break;
                case "Resume": TurnOffDetail(); break;
                case "Exit": SceneManager.LoadScene("Main_Menu"); break;
            }
            /* if (slot.name == "Setting")
             {
                 GoToDetailSelection("Audio Setting");
             }
             if (slot.name == "Tutorial")
             {
                 GoToDetailSelection("Tutorial");
             }
             if (slot.name == "Resume")
             {
                 TurnOffDetail();
             }
             if (slot.name == "Exit")
             {

             }*/
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TurnOffDetail();
        }
    }

    private void TurnOffDetail()
    {
        if (displayStack.Count == 1)
        {
            transform.gameObject.SetActive(false);
        }
        else
        {
            displayStack.Peek().gameObject.SetActive(false);
            displayStack.Pop();
            displayStack.Peek().gameObject.SetActive(true);
        }
    }

    private void GoToDetailSelection(string targetName)
    {
        GameObject detailGO = GameObject.Find("Detail Selection");
        GameObject detailSlot = detailGO.transform.Find(targetName).gameObject;


        if (detailSlot != null)
        {
            displayStack.Peek().gameObject.SetActive(false);
            detailSlot.SetActive(true);
            displayStack.Push(detailSlot);
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
        inventory.SetActive(false);
        skilTree.SetActive(false);

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
