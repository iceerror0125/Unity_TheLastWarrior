using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;
    public Common1 common1;
    public Common2 common2;
    public Common3 common3;
    public Bee bee;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(instance.gameObject); }
    }
  
}
