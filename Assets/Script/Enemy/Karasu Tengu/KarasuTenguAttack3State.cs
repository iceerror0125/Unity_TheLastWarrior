using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarasuTenguAttack3State : EnemyState
{
    KarasuTengu tengu;
    bool flag;

    public KarasuTenguAttack3State(Enemy enemy, string animName) : base(enemy, animName) { }
    public override void Enter()
    {
        base.Enter();
        tengu = (KarasuTengu)enemy;

        tengu.SetIsAttack(true);
        flag = false;
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (tengu.isHitPlayer)
        {
            if (!flag)
            {
                tengu.player.Freeze(2);
                flag = true;
            }
        }

        if (!tengu.IsAttack)
        {
            // if merging tengu.isHitPlayer above with this, it may cause a delay effect 
            // because tengu.IsAttack trigger after tengu.isHitPlayer
            if (tengu.isHitPlayer)
                stateMachine.ChangeState(tengu.atk2);
            else
                stateMachine.ChangeState(tengu.battleState);
        }
    }
}
