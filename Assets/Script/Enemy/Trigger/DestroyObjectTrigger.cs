using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectTrigger : MonoBehaviour
{
    public void ActiveTrigger(Enemy enemy)
    {
        Destroy(enemy.transform.gameObject);
    }
}
