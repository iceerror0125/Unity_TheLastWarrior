using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtState : EnemyState
{
    public EnemyHurtState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = enemy.HurtTime;
        AudioManager.instance.environment.EnemyHurt();

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
            stateMachine.ChangeState(enemy.battleState);
        }
    }
}
