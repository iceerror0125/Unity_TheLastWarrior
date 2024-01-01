using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1BattleState : EnemyBattleState
{
    public Common1BattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        enemy.ChangeVelocity(enemy.MoveSpeed * 1.5f * enemy.EntityDir, enemy.rb.velocity.y);
    }
}
