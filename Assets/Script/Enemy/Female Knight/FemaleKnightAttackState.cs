using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleKnightAttackState : EnemyAttackState
{
    FemaleKnight fk;
    int atk2Rate;
    public FemaleKnightAttackState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        fk = (FemaleKnight)enemy;
       /* if (fk.isActivePhase2)
        {
            fk.anim.SetFloat("Speed", 2);
        }*/
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (!enemy.IsAttack)
        {
            if (fk.IsPlayerOutOfAttackCheck())
            {
                stateMachine.ChangeState(fk.atk2State);
            }

            atk2Rate = Random.Range(0, 2);
            if (atk2Rate == 1)
            {
                stateMachine.ChangeState(fk.atk2State);
            }
        }

       

        base.Update();
    }
}
