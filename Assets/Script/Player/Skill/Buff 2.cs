
using UnityEngine;

public class Buff2 : PlayerSkill
{
    protected override void SetUp()
    {
        if (player == null /*|| wasBuffed == 1*/)
        {
            return;
        }
        int offset = PlayerPrefs.GetInt("Buffed2_Offset", 0);
        int oldATK = PlayerPrefs.GetInt("Buffed2_OldATK", 0);

        // +50% damage
        if (oldATK != player.stat.Damage)
        {
            player.stat.SetDamage(player.stat.Damage - offset);
            offset = Mathf.RoundToInt(player.stat.Damage / 2);
            float plusDamage = player.stat.Damage + offset;
            player.stat.SetDamage(plusDamage);
            
            PlayerPrefs.SetInt("Buffed2_Offset", offset);
            PlayerPrefs.SetInt("Buffed2_OldATK", Mathf.RoundToInt(player.stat.Damage));

        }

    }
}
