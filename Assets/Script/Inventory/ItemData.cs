using UnityEngine;

public enum ItemType
{
    item,
    equipment
}

[CreateAssetMenu(fileName = "new item", menuName = "Data/Normal Item")]
public class ItemData : ScriptableObject
{
    public string id = System.Guid.NewGuid().ToString();
    [SerializeField] protected string itemName;
    [SerializeField] protected Sprite img;
    [SerializeField] protected ItemType type;
    [TextArea]
    [SerializeField] protected string description;

    public string ItemName => itemName;
    public Sprite Img => img;
    public ItemType Type => type;
    public  string Description => description;
}                                               
