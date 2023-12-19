using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_SkillTreeCursorController : MonoBehaviour
{
    [SerializeField] private Transform cursor;
    [SerializeField] private Transform initSkillSlot;
    [SerializeField] private UI_SkillExplain explain;

    private Transform currentSkillSlot;
    private UI_SkillSlot uiSkillSlot;
    void Start()
    {
        InitCursor();
    }

    void Update()
    {
        HandleArrowInput();
    }
    void HandleArrowInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (uiSkillSlot.Left != null)
            {
                SetNewPosition(uiSkillSlot.Left);
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (uiSkillSlot.Right != null)
            {
                SetNewPosition(uiSkillSlot.Right);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (uiSkillSlot.Up != null)
            {
                SetNewPosition(uiSkillSlot.Up);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (uiSkillSlot.Down != null)
            {
                SetNewPosition(uiSkillSlot.Down);
            }
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PlayerSkill skill = currentSkillSlot.GetComponent<UI_SkillSlot>().Skill;
            if (skill.IsActiveSkill && skill.IsUnlock)
            {
                DialogManager.instance.ShowSetSkillKeyDialog(skill);
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // condition to unlock
            currentSkillSlot.GetComponent<UI_SkillSlot>().Unlock();
        }
    }

    private void SetNewPosition(Transform newPosition)
    {
        currentSkillSlot = newPosition;
        uiSkillSlot = currentSkillSlot.GetComponent<UI_SkillSlot>();
        cursor.SetParent(newPosition);
        RectTransform rect = cursor.GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
        // explain skill detail
        explain.ShowExplain(uiSkillSlot.Skill);
    }

    public void InitCursor()
    {
        cursor.gameObject.SetActive(true);
        currentSkillSlot = initSkillSlot;
        uiSkillSlot = currentSkillSlot.GetComponent<UI_SkillSlot>();
        SetNewPosition(currentSkillSlot);
    }
}
