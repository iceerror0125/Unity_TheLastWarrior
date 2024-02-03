using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    [SerializeField] private Enemy boss;
    [SerializeField] private Gate[] gates;
    private bool wasCalled;
    void Start()
    {
        
    }

    void Update()
    {
        if (boss == null && !wasCalled)
        {
            wasCalled = true;
            for (int i = 0; i < gates.Length; i++)
            {
                gates[i].Deactivate();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null && boss != null)
        {
            GameManager.Instance.isCutScene = true;
            for (int i = 0; i < gates.Length; i++)
            {
                gates[i].Activate();
            }
        }
    }
}
