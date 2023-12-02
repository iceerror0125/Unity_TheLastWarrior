using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(string _animName)
    {
        animName = _animName;
        player.SetIsFirstAttack(true);
    }
    public override void Enter()
    {
        base.Enter();
        player.SetAttackDir(player.MoveDir());
        timer = player.AttackCountDown();
    }

    public override void Exit()
    {
        base.Exit();
        if (!player.IsFirstAttack())
        {
            animName = "Player_Attack2";
        }
        else
        {
            animName = "Player_Attack1";
        }
    }

    public override void Update()
    {
        base.Update();

        if (player.AttackDir() != player.MoveDir())
        {
            player.ZeroVelocity();
            player.SetAttackDir(player.MoveDir());
        }

        Debug.Log("Attack State");
    }
}
