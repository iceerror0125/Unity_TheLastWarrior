using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common1BattleState : Common1State
{
    float exitBattleStateTimer;
    Player player;

    public Common1BattleState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        common1.SetIsDetectedPlayer(true);
        common1.ZeroVelocity();
        timer = 0.2f;
        exitBattleStateTimer = common1.ExitBattleStateTime;

        player = PlayerManager.instance.player;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        exitBattleStateTimer -= Time.deltaTime;

        if (timer < 0)
        {
            var battleSpeed = new Vector2((common1.MoveSpeed() + 2) * common1.EntityDir(), common1.rb.velocity.y);
            common1.ChangeVelocity(battleSpeed);
        }

        ChangeState();
        ChansingPlayer();
    }

    private void ChangeState()
    {
        if (exitBattleStateTimer < 0 || player.stat.IsDead)
        {
            stateMachine.ChangeState(common1.idleState);
        }

        if (common1.IsPlayerInAttackRange())
        {
            stateMachine.ChangeState(common1.attackState);
        }
    }

    private void ChansingPlayer()
    {
        if (common1.EntityDir() > 0 && common1.transform.position.x - 0.4 > player.transform.position.x)
        {
            common1.Flip();
        }
        else if (common1.EntityDir() < 0 && common1.transform.position.x + 0.4 < player.transform.position.x)
        {
            common1.Flip();
        }
    }
}
