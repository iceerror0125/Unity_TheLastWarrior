using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "new item", menuName = "Data/Equipment Item")]
public class ItemDataEquipment : ItemData
{
    [SerializeField] private int damage;
    [SerializeField] private int critRate;
    [SerializeField] private int critDamage;

    public int Damage => damage;
    public int CritRate => critRate;
    public int CritDamage => critDamage;
}
