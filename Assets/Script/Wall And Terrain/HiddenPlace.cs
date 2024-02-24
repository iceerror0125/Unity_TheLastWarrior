using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPlace : MonoBehaviour
{
    [SerializeField] private GameObject triggerItem;

    void Update()
    {
        if (triggerItem != null)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
