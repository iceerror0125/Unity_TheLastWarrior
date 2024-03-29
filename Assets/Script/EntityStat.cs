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
    protected bool hasRespawn;


    public System.Action<float> onChangeHP;
    #region Get Set
    public float MaxHp => maxHp;
    public float Hp => hp;
    public void SetHP(float value) => hp = Mathf.Round(value);
    public float Damage => damage;
    public float SetDamage(float _value) => damage = Mathf.Round(_value);
    public float CritRate => critRate;
    public float SetCritRate(float _value) => critRate = Mathf.Round(_value * Mathf.Pow(10, 1)) / Mathf.Pow(10, 1);
    public float CritDamage => critDamage;
    public float SetCritDamage(float _value) => critDamage = Mathf.Round(_value);
    public float SetMaxHp(float _value) => maxHp = _value;
    #endregion

    private void Start()
    {
        if (hp == 0)
        {
            hp = maxHp;
        }
        entity = GetComponent<Entity>();
    }

    public virtual void TakeDamage(float damage, bool isDeadZone = false)
    {
        hp -= damage;

        if (hp <= 0)
        {
            if (!isDeadZone)
            {
                CanRespawn();
            }

            if (!hasRespawn)
            {
                entity.SetIsDead(true);
                ShowDeadUI();
            }
            else
            {
                hasRespawn = false;
            }
        }
    }


    protected virtual void CanRespawn()
    {

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
