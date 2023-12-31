using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Common2BattleState : EnemyBattleState
{
    private Player player;
    private Common2 common2;
    public Common2BattleState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        common2 = (Common2)enemy;
        timer = common2.BattleToExplodeTime;
        player = PlayerManager.instance.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        common2.ChangeVelocity(common2.MoveSpeed * common2.EntityDir * 3, common2.rb.velocity.y);

        if (timer < 0)
        {
            stateMachine.ChangeState(common2.DeadState);
        }


        CheckExplosion();
    }
    private void CheckExplosion()
    {
        if (Vector2.Distance(common2.transform.position, player.transform.position) < 1)
        {
            stateMachine.ChangeState(common2.DeadState);
        }
        if (common2.IsWall)
        {
            stateMachine.ChangeState(common2.DeadState);
        }
    }
}
