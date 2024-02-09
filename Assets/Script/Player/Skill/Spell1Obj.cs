using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell1Obj : MonoBehaviour
{
    private List<GameObject> oldEnemies = new List<GameObject>();
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
       
        Enemy enemy = collision.GetComponent<Enemy>();
        EntityStat stat = PlayerManager.instance.player.stat;

        bool isOldEnemy = oldEnemies.Contains(collision.gameObject);

        if (enemy != null && !isOldEnemy)
        {
            Vector2 knockBack = new Vector2(30, 4);
            oldEnemies.Add(collision.gameObject);
            PlayerManager.instance.player.CauseDamage(enemy, stat.Damage, knockBack: knockBack);
        }
    }
}
