using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathProjectileSetUp : MonoBehaviour
{
    [SerializeField] private float existDuration;
    private float timer;
    private BringerOfDeath bod;
    private bool wasCauseDamage;
    private int counter;

    private Animator anim;
    private bool shouldReturnToFrame3 = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        timer = existDuration;
        wasCauseDamage = false;
        counter = 0;
    }

    public void Activate(BringerOfDeath bod)
    {
        this.bod = bod;
        Start();
        Update();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (shouldReturnToFrame3 && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
        {
            anim.Play("Projectile", 0, 3f / 12f); // 3f/12f represents the normalized time
            shouldReturnToFrame3 = false;
        }

        if (counter > 5)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        CauseDamage(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        CauseDamage(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        wasCauseDamage = false;
    }

    private void CauseDamage(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && !wasCauseDamage)
        {
            //bod.PerformSpellAttack(player, bod.stat.Damage + bod.stat.Damage / 2); // 150%
            bod.CauseDamage(player, bod.stat.Damage + bod.stat.Damage / 2); // 150%

            wasCauseDamage = true; // prevent trigger cause damage by frame
        }
    }

    public void LoopAnimation()
    {

    }

    public void SetReturnToFrame3()
    {
        shouldReturnToFrame3 = true;
        counter++;
    }
}
