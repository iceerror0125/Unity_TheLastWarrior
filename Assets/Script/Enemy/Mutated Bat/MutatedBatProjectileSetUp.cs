using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBatProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float delayDuration;
    [SerializeField] private float destroyObjectDuration = 1.5f;
    [SerializeField] private float atkRad;

    private float timer;
    private float destroyTimer;
    private bool trigger;
    private bool isCauseDamage;

    private Animator animator;
    private MutatedBat bat;


    public void Activate(MutatedBat bat)
    {
        Start();
        Update();
        this.bat = bat;
    }
    private void Start()
    {
        animator = GetComponent<Animator>();

        timer = delayDuration;
        destroyTimer = destroyObjectDuration;
        isCauseDamage = false;

        animator.speed = 0;
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        destroyTimer -= Time.deltaTime;

        if (timer < 0)
        {
            animator.speed = 1;
        }

        if (destroyTimer < 0)
        {
            Destroy(gameObject);
        }

        if (trigger)
        {
            TriggerPlayer();
        }
    }
    // use in animator
    public void EnableTrigger()
    {
        trigger = true;
    }
    // use in animator
    public void DisableTrigger()
    {
        trigger = false;
    }
    public void CancelAttack()
    {
        bat.SetIsAttack(false);
    }
    private void TriggerPlayer()
    {
        if (isCauseDamage)
        {
            return;
        }

        var hit = Physics2D.OverlapCircle(transform.position, atkRad);
        if (hit != null)
        {
            var player = hit.gameObject.GetComponent<Player>();
            if (player != null)
            {
                //bat.PerformNormalAttack(player);
                bat.CauseDamage(player, isCrit: true);

                isCauseDamage = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, atkRad);
    }
}
