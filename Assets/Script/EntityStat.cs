using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStat : MonoBehaviour
{

    [SerializeField] private float maxHp;
    [SerializeField] private float hp;
    [SerializeField] private float damage;
    [SerializeField] private float critRate;
    [SerializeField] private float critDamage;

    public System.Action onChangeHP;

    public float MaxHp => maxHp;
    public float Hp => hp;
    public float Damage => damage;
    public float CritRate => critRate;
    public float CritDamage => critDamage;

    protected virtual void Start()
    {
        hp = maxHp;
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;

        onChangeHP();
        /*if (onChangeHP != null)
        {
            onChangeHP();
        }*/
    }

}
