using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasuTengu : GroundEnemy
{
    [Header("Karasu Tengu Setting")]
    [SerializeField] private GameObject phase2;
    [SerializeField] private GameObject alert;

    public bool isHitPlayer { get; private set; }
    public void SetIsHitPlayer(bool isHitPlayer) => this.isHitPlayer = isHitPlayer;
    public KarasuTenguAttack2State atk2 { get; private set; }
    public KarasuTenguAttack3State atk3 { get; private set; }

    protected override void Start()
    {
        base.Start();

        attackState = new EnemyAttackState(this, "KarasuTengu_Attack1");
        deadState = new EnemyDeadState(this, "KarasuTengu_Dead");
        battleState = new EliteEnemyBattleState(this, "KarasuTengu_Move");
        hurtState = new EnemyHurtState(this, "KarasuTengu_Hit");
        idleState = new EnemyIdleState(this, "KarasuTengu_Idle");
        moveState = new EnemyMoveState(this, "KarasuTengu_Move");
        atk2 = new KarasuTenguAttack2State(this, "KarasuTengu_Attack2");
        atk3 = new KarasuTenguAttack3State(this, "KarasuTengu_Attack3");

        skillList.Add(atk2);
        skillList.Add(atk3);

        skillIndex = skillList.Count / 2;
        stateMachine.InitState(idleState);

        phase2.SetActive(false);
        alert.SetActive(false);

    }

    protected override void ActivePhase2()
    {
        base.ActivePhase2();
        phase2.SetActive(true);
    }
    public void EnableAlert()
    {
        alert.SetActive(true);
    }
    public void DisableAlert()
    {
        alert.SetActive(false);
    }
}
