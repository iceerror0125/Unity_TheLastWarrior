using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringerOfDeathSkill2 : EnemyState
{
    BringerOfDeath bod;
    public BringerOfDeathSkill2(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bod = (BringerOfDeath)enemy;

        bod.isImmortal = true;
        bod.SetIsReverse(false);

        timer = 2;
        PlayAnim();
    }

    public override void Exit()
    {
        base.Exit();
        bod.SetIsAppear(false);
    }

    public override void Update()
    {
        base.Update();
       
        if (timer < 0)
        {
            ReverseAnim();
            AppearBehindPlayer();
            timer = 0.5f; // prevent Update appear position constantly
        }

        if (bod.isAppear)
        {
            stateMachine.ChangeState(bod.attackState);
        }
    }

    private void AppearBehindPlayer()
    {
        bod.isImmortal = false;
        // appear behind player
        Vector2 pos = bod.player.transform.position;
        float dir = bod.player.EntityDir * -1; // opposite of player dir
        Vector2 spawn = new Vector2(pos.x + 2.2f * dir, pos.y + 0.4f);
        bod.transform.position = spawn;

        // face to player
       /* if (bod.player.EntityDir > 0)
        {
            bod.SetIsFacingRight(true);
        }
        else if (bod.player.EntityDir < 0)
        {
            bod.Flip();
        }*/

        if (dir == bod.EntityDir)
        {
            bod.Flip();
        }
    }

    private void ReverseAnim()
    {
        bod.SetIsReverse(true);
        enemy.anim.SetFloat("Reverse", -1);
        enemy.anim.Play(animName);
    }
    private void PlayAnim()
    {
        enemy.anim.SetFloat("Reverse", 1);
        enemy.anim.Play(animName);
    }
}
