using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockWall : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
}
