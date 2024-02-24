using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(OneTimeAppear))]
public class BlockWall : MonoBehaviour
{
    [SerializeField] private GameObject target;
    
    void Update()
    {
        if (target == null)
        {
            GetComponent<OneTimeAppear>().DestroyOTA();
            Destroy(gameObject);
        }
    }
}
