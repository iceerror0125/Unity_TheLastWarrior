using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Common1 common1;
    public Common2 common2;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(instance.gameObject); }
    }
  
}
