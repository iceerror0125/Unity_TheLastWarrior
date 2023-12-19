using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityStat : MonoBehaviour
{

    [SerializeField] protected float maxHp;
    [SerializeField] protected float hp;
    [SerializeField] protected float damage;
    [Range(0f, 1f)] 
    [SerializeField] protected float critRate;
    [SerializeField] protected float critDamage;

    [SerializeField] protected bool isDead;

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

    public virtual void TakeDamage(float _damage)
    {
        hp -= _damage;

        if (hp <= 0)
        {
            isDead = true;
        }
    }

    public virtual void CauseDamage(Entity _hitEntity)
    {
        float plusDamage = 0;

        float crit = Random.Range(0, 100);
        if (crit < critRate*100)
        {
            plusDamage += critDamage;
        }

        float totalDamage = damage + plusDamage;
        _hitEntity.stat.TakeDamage(totalDamage);
    }
}
