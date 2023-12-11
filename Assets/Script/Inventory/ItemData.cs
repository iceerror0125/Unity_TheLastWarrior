using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    item,
    equipment
}

[CreateAssetMenu(fileName = "new item", menuName = "Data/Normal Item")]
public class ItemData : ScriptableObject
{
    public string id; // remember to change to protected after accomplish testing
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite img;
    [SerializeField] protected ItemType type;

    public string ItemName => itemName;
    public Sprite Img => img;
    public ItemType Type => type;

    private void OnValidate()
    {
        id = System.Guid.NewGuid().ToString();  
    }
}
