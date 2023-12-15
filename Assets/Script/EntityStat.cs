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

    [SerializeField] private bool isDead;

    public System.Action<float> onChangeHP;
    #region Get Set
    public float MaxHp => maxHp;
    public float Hp => hp;
    public float Damage => damage;
    public float SetDamage(float _value) => damage = _value;
    public float CritRate => critRate;
    public float SetCritRate(float _value) => critRate = _value;
    public float CritDamage => critDamage;
    public float SetCritDamage(float _value) => critDamage = _value;
    public bool IsDead => isDead;
    #endregion

    protected virtual void Start()
    {
        hp = maxHp;
        isDead = false;
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            isDead = true;
        }
    }
}
