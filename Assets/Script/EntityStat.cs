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
    public float SetMaxHp(float _value) => maxHp = _value;
    #endregion

    private void Start()
    {
        hp = maxHp;
        entity = GetComponent<Entity>();
        critDamage = damage;
    }

    public virtual void TakeDamage(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            entity.SetIsDead(true);
            ShowDeadUI();
            //entity.stateMachine.ChangeState(entity.deadState);
        }
    }

    public virtual void ShowDeadUI() { }

    public void PerformNormalAttack(Entity hitEntity)
    {
        if (hitEntity.IsDead) return;

        if (hitEntity.isImmortal) return;

        float plusDamage = 0;

        float crit = Random.Range(0, 100);
        if (crit < critRate * 100)
        {
            plusDamage += critDamage;
        }

        float totalDamage = damage + plusDamage;
        hitEntity.TakeDamage(totalDamage);
        hitEntity.canKnockback = true;
    }

    public void PerformSpellAttack(Entity hitEntity, float damage)
    {
        if (hitEntity.IsDead) return;

        if (hitEntity.isImmortal) return;

        hitEntity.TakeDamage(damage);

        hitEntity.canKnockback = true;
    }

    public bool DoesCauseDamage(Entity hitEntity, float damage, bool isCrit)
    {
        if (hitEntity.isImmortal || hitEntity.IsDead) return false;

        float plusDamage = 0;
        if (isCrit)
        {
            float crit = Random.Range(0, 100);
            if (crit < critRate * 100)
            {
                plusDamage += critDamage;
            }
        }
        float totalDamage = damage + plusDamage;
        hitEntity.TakeDamage(totalDamage);
        return true;
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
