using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common2 : GroundEnemy
{

    [Header("Common 2 Battle Setting")]
    [SerializeField] private float battleToExplodeTime;
    private bool isInDeadState; // Not Moving in dead state

    public void SetIsInDeadState(bool _value) => isInDeadState = _value;
    public float BattleToExplodeTime => battleToExplodeTime;

    protected override void Start()
    {
        battleState = new Common2BattleState(this, "Common2_Move");
        deadState = new Common2DeadState(this, "Common2_Explode");
        moveState = new EnemyMoveState(this, "Common2_Move");
        hurtState = new EnemyHurtState(this, "Common2_Hurt");
        stateMachine.InitState(moveState);
    }
    protected override void Update()
    {
        if (isInDeadState)
            return;

        base.Update();
    }

}
