using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasuTenguAttack2State : EnemyState
{
    KarasuTengu tengu;
    float oriCritRate;
    public KarasuTenguAttack2State(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        tengu = (KarasuTengu)enemy;
        oriCritRate = tengu.stat.CritRate;
        tengu.stat.SetCritRate(100);

        tengu.SetIsAttack(true);
    }

    public override void Exit()
    {
        base.Exit();
        tengu.stat.SetCritRate(oriCritRate);
    }

    public override void Update()
    {
        base.Update();
        if (!tengu.IsAttack)
        {
            stateMachine.ChangeState(tengu.battleState);
        }
    }
}
