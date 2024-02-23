using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBat : FlyEnemy
{
    [SerializeField] private GameObject projectilePrefab;
    public MutatedBatSkillState skill { get; private set; }

    protected override void Start()
    {
        base.Start();
        deadState = new EnemyDeadState(this, "MutatedBat_Dead");
        hurtState = new EnemyHurtState(this, "MutatedBat_Idle");
        attackState = new MutatedBatAttackState(this, "MutatedBat_Idle");
        battleState = new MutatedBatBattleState(this, "MutatedBat_Idle");
        idleState = new EnemyIdleState(this, "MutatedBat_Idle");
        moveState = new FlyEnemyMoveState(this, "MutatedBat_Idle");
        skill = new MutatedBatSkillState(this, "MutatedBat_Idle");

        skillList.Add(skill);
        skillIndex = skillList.Count;

        stateMachine.InitState(idleState);
    }


    protected override void Update()
    {
        base.Update();
        if (attackCount == 3)
        {
            stateMachine.ChangeState(skill);
        }
    }

    public GameObject InstantiateProjectile()
    {
        var playerPos = player.transform.position;
        Vector2 spawnPos = new Vector2(playerPos.x, playerPos.y + 0.2f);
        return Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        //return Instantiate(projectilePrefab, transform);
    }
}
