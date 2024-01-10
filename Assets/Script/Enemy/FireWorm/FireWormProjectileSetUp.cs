using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWormProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float existTimer;

    private Transform target;
    private FireWorm fireWorm;

    float firingAngle = 1f;
    float gravity = 1f;

    float flightDuration;
    float elapse_time;
    float Vx, Vy;
    float rotationChange;

    void Start()
    {
        fireWorm = GetComponentInParent<FireWorm>();
        target = PlayerManager.instance.player.transform;

        transform.position = fireWorm.transform.position;

        SimulateProjectile();
    }

    public void Activate()
    {
        Start();
        Update();
    }


    void Update()
    {
        existTimer -= Time.deltaTime;



        if (existTimer < 0)
        {
            Destroy(gameObject);
        }

        if (elapse_time < flightDuration)
        {
            // Multiply by -1 if on the player's right, 1 if on the player's left
            /*if (common3.IsOnTheRightOfPlayer())
            {
                rotationChange = -1;
            }
            else
            {
                rotationChange = 1;
            }*/
            transform.Translate(Vx * Time.deltaTime, (Vy - (gravity * elapse_time)) * Time.deltaTime /** rotationChange*/, 0);

            elapse_time += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            //fireWorm.PerformNormalAttack(collision.GetComponent<Player>());
            fireWorm.CauseDamage(collision.GetComponent<Player>(), isCrit: true);

        }
    }
    void SimulateProjectile()
    {
        // Move projectile to the position of throwing object + add some offset if needed.
        //projectTile.position = fireWorm.transform.position;

        // Calculate distance to target
        float target_Distance = Vector2.Distance(transform.position, target.transform.position);

        // Calculate the velocity needed to throw the object to the target at specified angle.
        float projectile_Velocity = target_Distance / (Mathf.Sin(2 * firingAngle * Mathf.Deg2Rad) / gravity);

        // Extract the X  Y componenent of the velocity
        Vx = Mathf.Sqrt(projectile_Velocity) * Mathf.Cos(firingAngle * Mathf.Deg2Rad);
        Vy = Mathf.Sqrt(projectile_Velocity) * Mathf.Sin(firingAngle * Mathf.Deg2Rad);

        Vx *= speed;
        Vy /= speed;
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
