using UnityEngine;

public class EntityStat : MonoBehaviour
{
    private Entity entity;

    [SerializeField] protected float maxHp;
    [SerializeField] protected float hp;
    [SerializeField] protected float damage;
    [Range(0f, 1f)]
    [SerializeField] protected float critRate;
    [SerializeField] protected float critDamage;


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
    #endregion

    private void Start()
    {
        hp = maxHp;
        entity = GetComponent<Entity>();
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            entity.SetIsDead(true);
        }
    }

    public void PerformNormalAttack(Entity hitEntity)
    {
        float plusDamage = 0;

        float crit = Random.Range(0, 100);
        if (crit < critRate * 100)
        {
            plusDamage += critDamage;
        }

        float totalDamage = damage + plusDamage;
        hitEntity.TakeDamage(totalDamage);
    }

    public void PerformSpellAttack(Entity hitEntity, float damage)
    {
        hitEntity.TakeDamage(damage);
    }

    public void RecoverHP(float recoverHP)
    {
        hp += recoverHP;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        onChangeHP(hp);
    }

}
