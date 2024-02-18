using UnityEngine;

public class BringerOfDeath : GroundEnemy
{
    [Header("Bringer Of Death Setting")]
    [SerializeField] private GameObject projectilePrefab;

    public bool  isAppear { get; private set; }
    public bool isReverse { get; private set; }
    public BringerOfDeathSkill1 skill1 { get; private set; }
    public BringerOfDeathSkill2 skill2 { get; private set; }

    public void SetIsAppear(bool value) => isAppear = value;
    public void SetIsReverse(bool value) => isReverse = value;


    protected override void Start()
    {
        base.Start();

        attackState = new EnemyAttackState(this, "BringerOfDeath_Attack");
        deadState = new EnemyDeadState(this, "BringerOfDeath_Dead");
        battleState = new EliteEnemyBattleState(this, "BringerOfDeath_Move");
        hurtState = new EnemyHurtState(this, "BringerOfDeath_Hurt");
        idleState = new EnemyIdleState(this, "BringerOfDeath_Idle");
        moveState = new EnemyMoveState(this, "BringerOfDeath_Move");
        skill1 = new BringerOfDeathSkill1(this, "BringerOfDeath_Skill");
        skill2 = new BringerOfDeathSkill2(this, "BringerOfDeath_Skill2");

        skillList.Add(skill1);
        skillList.Add(skill2);

        skillIndex = skillList.Count / 2;
        stateMachine.InitState(idleState);
    }


    public GameObject InstantiateProjectile()
    {
        var playerPos = player.transform.position;
        Vector2 spawnPos = new Vector2(playerPos.x, playerPos.y + 1);
        return Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        //return Instantiate(projectilePrefab, transform);
    }
}
