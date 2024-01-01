using UnityEngine;

public class Spell1Obj : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        EntityStat stat = PlayerManager.instance.player.stat;
        if (enemy != null )
        {
            /*Vector2 hit = new Vector2(30 * enemy.EntityDir() * - 1, 4);
            enemy.ChangeVelocity(hit);*/
            Vector2 knockBack = new Vector2(30, 4);
            PlayerManager.instance.player.PerformSpellAttack(enemy, stat.Damage + stat.Damage * 0.5f, knockBack);
            //stat.CauseDamage(enemy, stat.Damage + stat.Damage * 0.5f); //150%
        }
    }
}
