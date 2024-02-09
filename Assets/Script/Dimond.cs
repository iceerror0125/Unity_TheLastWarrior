using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dimond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>() != null)
        {
            SkillManager.instance.PlusDimond();
            AudioManager.instance.environment.PickUpItem();
            Destroy(gameObject);
        }
    }
}
