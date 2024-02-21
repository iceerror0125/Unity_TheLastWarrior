using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyEnemyMoveState : EnemyMoveState
{
    Vector2 moveVector;
    FlyEnemy flyEnemy;
    private float outFlyBoxTimer;
    private bool isOutOfBox;
    public FlyEnemyMoveState(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timer = enemy.MoveDuration;
        flyEnemy = (FlyEnemy)enemy;

        moveVector = CalculateMoveVector();
        outFlyBoxTimer = 2;

        if (!flyEnemy.IsInsideFlyBox(flyEnemy.transform.position))
        {
            isOutOfBox = true;
        }
        else
        {
            isOutOfBox = false;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        outFlyBoxTimer -= Time.deltaTime;

        if (isOutOfBox)
        {
            if (!flyEnemy.isInOriginalPos())
            {
                return;
            }
           
        }
      

        base.Update();
        enemy.ChangeVelocity(enemy.MoveSpeed * moveVector.x, moveVector.y);
    }

    private Vector2 CalculateMoveVector()
    {
        float x = Random.Range(0, enemy.MoveRange.x);
        if (enemy.EntityDir < 0)
        {
            x *= -1;
        }

        float y = Random.Range(-enemy.MoveRange.y, enemy.MoveRange.y);
      
        return new Vector2(x, y);
    }
}
