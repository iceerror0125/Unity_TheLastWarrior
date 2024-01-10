using UnityEngine;

public class Spell3SetUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float rad;
    public bool isSuck;
    private float timer;

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
            var enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.transform.position = Vector2.MoveTowards(enemy.transform.position, transform.position, speed * Time.deltaTime);
                //PlayerManager.instance.player.PerformSpellAttack(enemy, PlayerManager.instance.player.stat.Damage * 0.2f);
                PlayerManager.instance.player.CauseDamage(enemy, PlayerManager.instance.player.stat.Damage * 0.2f);

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
