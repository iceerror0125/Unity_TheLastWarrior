using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleKnight : GroundEnemy
{
    [Header("Female Knight Setting")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject phase2;

   
    public FemaleKnightAttack2State atk2State { get; private set; }
    public FemaleKnightSkill skill { get; private set; }
    protected override void Start()
    {
        base.Start();

        attackState = new FemaleKnightAttackState(this, "FemaleKnight_Attack");
        deadState = new EnemyDeadState(this, "FemaleKnight_Dead");
        battleState = new EliteEnemyBattleState(this, "FemaleKnight_Move");
        hurtState = new EnemyHurtState(this, "FemaleKnight_Hit");
        idleState = new EnemyIdleState(this, "FemaleKnight_Idle");
        moveState = new EnemyMoveState(this, "FemaleKnight_Move");
        atk2State = new FemaleKnightAttack2State(this, "FemaleKnight_Attack 2");
        skill = new FemaleKnightSkill(this, "FemaleKnight_Idle");

        skillList.Add(skill);

        skillIndex = skillList.Count / 2;
        phase2.SetActive(false);

        stateMachine.InitState(idleState);
    }
    protected override void ActivePhase2()
    {
        base.ActivePhase2();
        moveSpeed = moveSpeed * 2;
        stat.SetDamage(stat.Damage * 1.5f);
        stat.SetCritRate(0.5f);

        anim.SetFloat("Speed", 2);
        phase2.SetActive(true);
        
    }
    public bool IsPlayerOutOfAttackCheck()
    {
        var collider = Physics2D.OverlapCircle(attackCheck.position, attackCheckRadius);
        if (collider != null)
        {
            if (collider.GetComponent<Player>() != null)
            {
                return false;
            }
        }
        return true;
    }
    public GameObject InstantiateProjectile()
    {
        Vector2 spawnPos = new Vector2(transform.position.x + 2f * entityDir, transform.position.y);
        return Instantiate(projectilePrefab, spawnPos, Quaternion.identity);
        // return Instantiate(projectilePrefab, transform);
    }
}
