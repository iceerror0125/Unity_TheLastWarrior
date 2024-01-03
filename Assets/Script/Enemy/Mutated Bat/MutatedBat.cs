using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBat : FlyEnemy
{
    [SerializeField] private GameObject projectilePrefab;

    protected override void Start()
    {
        base.Start();
        deadState = new EnemyDeadState(this, "MutatedBat_Dead");
        hurtState = new EnemyHurtState(this, "MutatedBat_Idle");
        attackState = new MutatedBatAttackState(this, "MutatedBat_Idle");
        battleState = new EnemyBattleState(this, "MutatedBat_Idle");
        idleState = new EnemyIdleState(this, "MutatedBat_Idle");
        moveState = new FlyEnemyMoveState(this, "MutatedBat_Idle");

        stateMachine.InitState(idleState);
    }

    public GameObject InstantiateProjectile()
    {
        var playerPos = player.transform.position;
        Vector2 spawnPos = new Vector2(playerPos.x, playerPos.y + 0.2f);
        return Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        //return Instantiate(projectilePrefab, transform);
    }
}
