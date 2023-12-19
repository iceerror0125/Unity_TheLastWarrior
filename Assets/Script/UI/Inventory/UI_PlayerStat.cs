using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_PlayerStat : MonoBehaviour
{
    public static UI_PlayerStat instance;

    PlayerStat stat;
    [SerializeField] private TextMeshProUGUI text;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance.gameObject);
        }
    }
    public void UpdateStat()
    {
        stat = PlayerManager.instance.player.stat as PlayerStat;
        string sMaxHP = stat.MaxHp.ToString();
        string sCurrentHP = stat.Hp.ToString();
        string sDamage = stat.Damage.ToString();
        string sCritRate = (stat.CritRate * 100).ToString();
        string sCritDamage = stat.CritDamage.ToString();

        text.text = $"HP: {sCurrentHP} / {sMaxHP} " +
            $"\n\n DMG: {sDamage}" +
            $"\n\n Crit rate: {sCritRate}%" +
            $"\n\n Crit DMG: {sCritDamage}";
    }
}
