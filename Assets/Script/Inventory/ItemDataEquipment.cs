using UnityEngine;


[CreateAssetMenu(fileName = "new item", menuName = "Data/Equipment Item")]
public class ItemDataEquipment : ItemData
{
    [SerializeField] private int damage;
    [Range(0f, 1f)]
    [SerializeField] private float critRate;
    [SerializeField] private int critDamage;

    public int Damage => damage;
    public float CritRate => critRate;
    public int CritDamage => critDamage;
}
