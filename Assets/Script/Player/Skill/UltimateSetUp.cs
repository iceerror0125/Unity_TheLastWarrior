using UnityEngine;

public class UltimateSetUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float countdown;
    [SerializeField] private float damageCountdown;

    private Vector3 scaleChange;
    private float scaleTimer;
    public Vector3 size;
    void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, 0.01f, transform.localScale.z);
        scaleChange = new Vector3(0, speed, 0);
        scaleTimer = countdown;
    }

    void Update()
    {
        scaleTimer -= Time.deltaTime;
       
        Action();
    }
    private void Action()
    {
        if (scaleTimer < 0)
        {
            if (transform.localScale.y < 1)
                transform.localScale += scaleChange;
        }
    }
    public void ReverseRotation()
    {
        transform.Rotate(0, 180, 0);
    }
    public void Activate()
    {
        Start();
        Update();
    }
    public void DestroySkill()
    {
        Destroy(gameObject);
    }
    
    public void CauseDamage()
    {
        if (transform.localScale.y < 0.99)
            return;

        var colliders = Physics2D.OverlapBoxAll(transform.position, size, 0);
        foreach (var collider in colliders)
        {
            Enemy enemy = collider.GetComponent<Enemy>();
            if (enemy != null)
            {
                PlayerManager.instance.player.SpellHit(enemy, PlayerManager.instance.player.stat.Damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, size);
    }
}
