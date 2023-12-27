using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common2 : GroundEnemy
{
    #region State
    public Common2BattleState battleState { get; private set; }
    public Common2DeadState deadState { get; private set; }
    public Common2MoveState moveState { get; private set; }
    #endregion
    [SerializeField] private float movingTime;
    [SerializeField] private float battleToExplodeTime;
    private bool isInDeadState;

    public void SetIsInDeadState(bool _value) => isInDeadState = _value;
    public float MovingTime => movingTime;
    public float BattleToExplodeTime => battleToExplodeTime;

    protected override void Start()
    {
        battleState = new Common2BattleState("Common2_Move");
        deadState = new Common2DeadState("Common2_Explode");
        moveState = new Common2MoveState("Common2_Move");
        stateMachine.InitState(moveState);
    }
    protected override void Update()
    {
        base.Update();

        if (DetectPlayer() && isDetected == false && !PlayerManager.instance.player.stat.IsDead)
        {
            if (!isInDeadState)
            {
            stateMachine.ChangeState(battleState);

            }
        }

       
       /* if (stat.IsDead)
        {
            stateMachine.ChangeState(deadState);
        }*/
    }

  
}
