using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;
    [SerializeField] private UI_SetSkillDialog setSkillDialog;
    [SerializeField] private UI_InfoDialog infoDialog;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(instance.gameObject); }
    }

    public void ShowSetSkillKeyDialog(PlayerSkill _skill)
    {
        setSkillDialog.ShowDialog(_skill);
    }
    public void ShowInfoDialog(ItemData _item)
    {
        infoDialog.ShowDialog(_item);
    }

}
