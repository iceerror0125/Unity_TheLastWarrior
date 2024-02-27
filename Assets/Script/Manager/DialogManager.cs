using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private UI_SetSkillDialog setSkillDialog;
    [SerializeField] private UI_InfoDialog infoDialog;

    public Queue<ItemData> stackDialog;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(instance.gameObject); }
        stackDialog = new Queue<ItemData>();
    }

    public void ShowSetSkillKeyDialog(PlayerSkill _skill)
    {
        setSkillDialog.ShowDialog(_skill);
    }
    public void ShowInfoDialog(ItemData _item)
    {
        stackDialog.Enqueue(_item);
        infoDialog.ShowDialog(stackDialog.Peek());
    }
    public void CloseDialog()
    {
        stackDialog.Dequeue();
        if (stackDialog.Count == 0)
        {
            // disable dialog
            infoDialog.CloseDialog();
        }
        else
        {
            infoDialog.ShowDialog(stackDialog.Peek());
        }
    }

}
