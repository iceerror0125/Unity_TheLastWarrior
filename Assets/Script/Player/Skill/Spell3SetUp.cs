using System.Collections.Generic;
using UnityEngine;

public class Spell3SetUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rad;
    public bool isSuck;
    private float timer;
    private List<GameObject> oldEnemies = new List<GameObject>();

    void Update()
    {
        timer -= Time.deltaTime;
        if (isSuck)
            SuckEnemies();

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }
    private void SuckEnemies()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rad);
        foreach (var collider in colliders)
        {
            bool isOldEnemy = oldEnemies.Contains(collider.gameObject);

            var enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null && !isOldEnemy)
            {
                oldEnemies.Add(collider.gameObject);
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, speed * Time.deltaTime);
                //PlayerManager.instance.player.PerformSpellAttack(enemy, PlayerManager.instance.player.stat.Damage * 0.2f);
                PlayerManager.instance.player.CauseDamage(enemy, PlayerManager.instance.player.stat.Damage * 0.5f);

            }
        }
    }

    public void TurnOnSuck()
    {
        isSuck = true;
    }
    public void TurnOffSuck()
    {
        isSuck = false;
        oldEnemies = new List<GameObject>();
    }

    public void Activate(float _duration)
    {
        isSuck = true;
        timer = _duration;
        Update();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rad);
    }
}
