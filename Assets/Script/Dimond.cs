using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Dimond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        if (collision.GetComponent<Player>() != null)
        {
            SkillManager.instance.PlusDimond();
            AudioManager.instance.environment.PickUpItem();

            OneTimeAppear ota = GetComponent<OneTimeAppear>();
            if (ota != null)
            {
                ota.DestroyOTA();
            }

            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void Update()
    {
        if (CheckGround())
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    }
    private bool CheckGround()
    {
        var x = Physics2D.Raycast(transform.position, Vector2.down, 1, 1 << 3);
        if (x)
        {
            return true;
        }
        return false;
    }
}
