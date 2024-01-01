using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Common3ProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float existTimer;
    private Common3 common3;

    float firingAngle = 30.0f;
    float gravity = 9.8f;
    Transform target;

    float flightDuration;
    float elapse_time;
    float Vx, Vy;
    float rotationChange;

    private void Start()
    {
        common3 = EnemyManager.instance.common3;
        target = common3.player.transform; 
        SimulateProjectile();
    }
    private void Update()
    {
        existTimer -= Time.deltaTime;
        if (existTimer < 0)
        {
            Destroy(gameObject);
        }

        if (elapse_time < flightDuration)
        {
            // Multiply by -1 if on the player's right, 1 if on the player's left
            if (common3.IsOnTheRightOfPlayer())
            {
                rotationChange = -1;
            }
            else
            {
                rotationChange = 1;
            }
            transform.Translate(Vx * Time.deltaTime, (Vy - (gravity * elapse_time)) * Time.deltaTime * rotationChange, 0);

            elapse_time += Time.deltaTime;
        }
    }

    public void Activate()
    {
        Start();
        Update();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            return;
        }

        if (collision.GetComponent<Player>() != null)
        {
            Player player = collision.GetComponent<Player>();
            EnemyManager.instance.common3.PerformNormalAttack(player);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3) // 3: Ground
        {
            Destroy(gameObject);
        }


    }

    void SimulateProjectile()
    {
        // Move projectile to the position of throwing object + add some offset if needed.
        //projectTile.position = common3.transform.position;

        // Calculate distance to target
        float target_Distance = Vector2.Distance(transform.position, target.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        Vx *= common3.ProjectileSpeed;
        Vy /= common3.ProjectileSpeed;
        // Calculate flight time.
        //flightDuration = target_Distance / Vx;
        flightDuration = 100;

        // Rotate projectile to face the target.
        //Projectile.rotation = Quaternion.LookRotation(Target.position - Projectile.position);
        Vector2 direction = (target.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.rotation = rotation;


        elapse_time = 0;
    }
}
