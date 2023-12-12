using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_Explain : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI description;


    public void SetUpExplainUI(ItemData item)
    {
        if (item == null)
        {
            image.sprite = null;
            image.color = new Color(0,0,0,0);
            itemName.text = "";
            description.text = "";
            return; 
        }

        image.color = Color.white;
        image.sprite = item.Img;
        itemName.text = item.ItemName;
        if (item.Type == ItemType.equipment) {
            ItemDataEquipment equipment  = item as ItemDataEquipment;   
            description.text = $"Damage: + {equipment.Damage}" +
                $"\n Crit rate: + {equipment.CritRate} " +
                $"\n Crit damage: + {equipment.CritDamage}";
        }
        else
        {
            description.text = item.Description;
        }
    }
}
