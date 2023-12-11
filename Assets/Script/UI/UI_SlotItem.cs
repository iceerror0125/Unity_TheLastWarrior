using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotItem : MonoBehaviour
{
    private Image img;

    public void SetupImageSlot(ItemData item)
    {
        img = GetComponentsInChildren<Image>()[1];

        if (item != null)
        {
            img.sprite = item.Img;
            img.color = Color.white;
        }
    }
    public void Clear()
    {
        img = GetComponentsInChildren<Image>()[1];
        img.sprite = null;
        img.color = new Color(0, 0, 0, 0);
    }
}
