using UnityEngine;
using UnityEngine.UI;


public class UI_InventoryCursorController : MonoBehaviour
{
    [SerializeField] private Transform cursor;
    [SerializeField] private Transform equipmentSlot;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private UI_Explain uiExplain;


    private int currentIndex;
    private int gridLenght;


    void Start()
    {
        gridLenght = gridLayoutGroup.transform.childCount;
        InitCursor();

        // load data
        LoadUIData();
    }

    

    void Update()
    {
        HandleArrowInput();
    }
    void HandleArrowInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveSelection(-1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveSelection(1, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveSelection(0, -1);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveSelection(0, 1);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            EquipAnndUnEquip();
        }
    }

    private void EquipAnndUnEquip()
    {
        UI_SlotItem data;
        Inventory inventory = Inventory.instance;
        //Debug.Log(currentIndex);
        if (currentIndex < 0)
        {
            // UnEquip weapon
            data = equipmentSlot.GetComponent<UI_SlotItem>();
            if (data.Data != null)
            {
                inventory.RemoveEquipment(data.Data as ItemDataEquipment);
                data.ClearSlot();
            }
        }
        else
        {
            // Equip weapon
            data = gridLayoutGroup.transform.GetChild(currentIndex).GetComponent<UI_SlotItem>();
            if (data.Data != null && data.Data.Type == ItemType.equipment)
            {
                inventory.AddEquipmentItem(data.Data as ItemDataEquipment);
                equipmentSlot.GetComponent<UI_SlotItem>().SetupImageSlot(data.Data);
                inventory.RemoveItem(data.Data);
            }
        }
    }

   

    void MoveSelection(int horizontal, int vertical)
    {
        int rowLenght = gridLayoutGroup.constraintCount;
        // navigate from equipment slot to stash slot when press any arrow key.
        if (currentIndex == -1)
        {
            SetCursorPosition(0);
            return;
        }
        // navigate to equipment slot when cursor is in first column
        if (currentIndex % rowLenght == 0 && horizontal == -1)
        {
            SetCursorPosition(-1);
            return;
        }

        int lr = 1 * horizontal;
        int ud = rowLenght * vertical;
        int index = lr + ud + currentIndex;

        if (index >= gridLenght) return;

        SetCursorPosition(index);


        AudioManager.instance.environment.MenuSelect();

    }

    private void SetCursorPosition(int position)
    {
        UI_SlotItem data;
        if (position < 0)
        {
            cursor.SetParent(equipmentSlot);
            data = equipmentSlot.GetComponent<UI_SlotItem>();
            currentIndex = -1;
        }
        else
        {
            cursor.SetParent(gridLayoutGroup.transform.GetChild(position));
            data = gridLayoutGroup.transform.GetChild(position).GetComponent<UI_SlotItem>();
            currentIndex = position;
        }

       
        RectTransform rect = cursor.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
        // show detail in explain ui
        uiExplain.SetUpExplainUI(data.Data);
    }

    public void InitCursor()
    {
        currentIndex = 0;
        cursor.gameObject.SetActive(true);
        SetCursorPosition(currentIndex);
    }

    private void LoadUIData()
    {
        Inventory inventory = Inventory.instance;
       
        if (inventory.equipSlot != null)
        {
            var data = inventory.equipSlot;
            equipmentSlot.GetComponent<UI_SlotItem>().SetupImageSlot(data);
        }
    }
}
