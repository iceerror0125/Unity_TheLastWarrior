using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_SlotItem : MonoBehaviour
{
    private Image img;
    private ItemData data;

    public ItemData Data => data;
    public void SetupImageSlot(ItemData item)
    {
        data = item;
        img = GetComponentsInChildren<Image>()[1];

        if (item != null)
        {
            img.sprite = item.Img;
            img.color = Color.white;
        }
    }
    public void SetUpVolume(int volume)
    {
        GameObject volumeObject = transform.Find("Volume BG").gameObject;
        if (volumeObject != null)
        {
            if (volume <= 1)
            {
                volumeObject.SetActive(false);
            }
            else
            {
                volumeObject.SetActive(true);
                TextMeshProUGUI volumeText = volumeObject.GetComponentInChildren<TextMeshProUGUI>();
                volumeText.text = volume.ToString();
            }
        }
    }
    public void ClearSlot()
    {
        img = GetComponentsInChildren<Image>()[1];
        img.sprite = null;
        img.color = new Color(0, 0, 0, 0);
        data = null;
    }
}
