using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Common1 : GroundEnemy
{
    #region Common 1 State
    public Common1AttackState attackState { get; private set; }
    public Common1BattleState battleState { get; private set; }
    public Common1IdleState idleState { get; private set; }
    public Common1MoveState moveState { get; private set; }
    public Common1DeadState deadState { get; private set; }
    public Common1HurtState hurtState { get; private set; }
    #endregion

    [Header("Move")]
    [SerializeField] private float moveDuration;
    [SerializeField] private float idleDuration;


    #region Getter Setter
    public float MoveDuration() => moveDuration;
    public float IdleDuration() => idleDuration;
  
    #endregion
    protected override void Start()
    {
        base.Start();

        #region Init Common 1 State
        attackState = new Common1AttackState("Common1_Attack");
        battleState = new Common1BattleState("Common1_Walk");
        idleState = new Common1IdleState("Common1_Idle");
        moveState = new Common1MoveState("Common1_Walk");
        deadState = new Common1DeadState("Common1_Dead");
        hurtState = new Common1HurtState("Common1_Hurt");
        #endregion

        stateMachine.InitState(idleState);
    }

    protected override void Update()
    {
        base.Update();

        //stateMachine.currentState.Update();

        if (DetectPlayer() && isDetected == false && !PlayerManager.instance.player.stat.IsDead)
        {
            stateMachine.ChangeState(battleState);
        }

        if (stat.IsDead)
        {
            stateMachine.ChangeState(deadState);
        }
    }

    public override void KnockBack(Entity _attacker, float x, float y)
    {
        base.KnockBack(_attacker, x, y);
        stateMachine.ChangeState(hurtState);
    }
}
