using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBatSkillState : EnemyState
{
    MutatedBat bat;

    private int counter;
    private float countdown;
    public MutatedBatSkillState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bat = (MutatedBat)enemy;

        counter = 4;
        countdown = 0.5f;
        timer = countdown;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (timer < 0)
        {
           
            bat.InstantiateProjectile().GetComponent<MutatedBatProjectileSetUp>().Activate(bat);
            timer = countdown;
            counter--;
            if (counter == 0)
            {
                bat.DefaultAttackCount();
                stateMachine.ChangeState(bat.battleState);
            }
        }
    }
}
