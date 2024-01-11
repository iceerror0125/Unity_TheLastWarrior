using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormHead : GroundEnemy
{
    [Header("Storm Head Setting")]
    [SerializeField] private GameObject projectilePrefab1;
    [SerializeField] private GameObject projectilePrefab2;
    [SerializeField] private GameObject phase2;

    [Header("Storm Head Attack Setting")]
    public Transform leftPoint;
    public Transform rightPoint;
    public bool isRightPoint;

    public StormHeadSkill1 skill1 { get; private set; }
    public StormHeadSkill2 skill2 { get; private set; }

    protected override void Start()
    {
        base.Start();

        attackState = new EnemyAttackState(this, "Storm head attack");
        deadState = new EnemyDeadState(this, "Storm head dead");
        battleState = new EliteEnemyBattleState(this, "Storm head move");
        hurtState = new EnemyHurtState(this, "Storm head hit");
        idleState = new EnemyIdleState(this, "Storm head idle");
        moveState = new EnemyMoveState(this, "Storm head move");
        skill1 = new StormHeadSkill1(this, "Storm head idle");
        skill2 = new StormHeadSkill2(this, "Storm head idle");

        skillList.Add(skill1);
        skillList.Add(skill2);

        skillIndex = skillList.Count / 2;
        stateMachine.InitState(idleState);

        phase2.SetActive(false);
        isRightPoint = true;
    }

    protected override void ActivePhase2()
    {
        base.ActivePhase2();
        phase2.SetActive(true);
    }

    public GameObject InstantiateProjectile()
    {
        var playerPos = player.transform.position;
        Vector2 spawnPos = new Vector2(playerPos.x, playerPos.y + 0.8f);
        return Instantiate(projectilePrefab1, spawnPos, Quaternion.identity);
        //return Instantiate(projectilePrefab, transform);
    }

    public GameObject InstantiateProjectile2()
    {
        var playerPos = transform.position;
        Vector2 spawnPos = new Vector2(playerPos.x + 0.2f, playerPos.y + 0.65f);
        return Instantiate(projectilePrefab2, spawnPos, Quaternion.identity);
        //return Instantiate(projectilePrefab2, transform);
    }
}
