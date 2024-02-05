using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuffType
{
    HP, ATK, CritRate, CritDamage
}
public class BuffItem : MonoBehaviour
{
    public BuffType buffType;
    [SerializeField] private float index;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
        {
            switch (buffType)
            {
                case BuffType.HP: 
                    player.stat.SetMaxHp(player.stat.MaxHp + index);
                    HUDManager.instance.UpdateHpBar();
                    break;
                case BuffType.ATK: player.stat.SetDamage(player.stat.Damage + index); break;
                case BuffType.CritDamage: player.stat.SetCritDamage(player.stat.CritDamage + index); break;
                case BuffType.CritRate: player.stat.SetCritRate(player.stat.CritRate + index); break;
            }
        }
    }
}
