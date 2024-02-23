using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutatedBatBattleState : EnemyBattleState
{
    MutatedBat bat;
    float moveX;
    float moveY;
    public MutatedBatBattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bat = (MutatedBat)enemy;
        /*if (bat.EntityDir > 0)
        {
            moveX = Random.Range(-4, 0);
        }
        else if (bat.EntityDir < 0)
        {
            moveX = Random.Range(0, 4);
        }*/
        moveX = Random.Range(-4, 4);

        moveY = Random.Range(-4, 4);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        bat.ChangeVelocity(moveX, moveY);
    }
}
