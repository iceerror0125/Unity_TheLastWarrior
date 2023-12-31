using UnityEngine;

public class Spell2SetUp : MonoBehaviour
{
    private Player player;
    private Vector2 nearestEnemy;
    private Vector2 direction;
    private Quaternion rotation;
    [SerializeField] private float fallSpeed;
    private float timer;
    void Start()
    {
        player = PlayerManager.instance.player;
        if (player.NeareastEnemy() == null)
            return;
        nearestEnemy = player.NeareastEnemy().transform.position;
        direction = nearestEnemy - (Vector2)transform.position;
        timer = 1;
    }
    void Update()
    {
        timer -= Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, nearestEnemy, fallSpeed * Time.deltaTime);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        if (timer < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            player.SpellHit(enemy, player.stat.Damage * 0.33f);
            Destroy(gameObject);
        }
    }
    public void Activate()
    {
        Start();
        Update();
    }
}
