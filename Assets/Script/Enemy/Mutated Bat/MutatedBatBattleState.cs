using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
        //bat.ChangeVelocity(moveX, moveY);
        FarFromPlayer();
    }

    private void FarFromPlayer()
    {
        if (Vector2.Distance(player.transform.position, bat.transform.position) < 5)
        {
            bat.ChangeVelocity(bat.MoveSpeed * bat.EntityDir * -1, bat.rb.velocity.y);
        }
    }

    private void CheckGroundAround()
    {
        var hit = Physics2D.OverlapCircle(bat.transform.position, 1.3f, 1 << 3);
        if (hit != null)
        {
            if (timer < 0)
            {
                timer = 2;
            }
        }
    }
}
