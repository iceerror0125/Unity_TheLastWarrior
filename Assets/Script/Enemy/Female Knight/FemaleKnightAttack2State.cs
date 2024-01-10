using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleKnightAttack2State : EnemyAttackState
{
    const float radOffset = 1.43f;
    const float xOffset = 1.13f;
    Vector2 origin;
    public FemaleKnightAttack2State(Enemy enemy, string animName) : base(enemy, animName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetAttackCheckRadius(enemy.AttackCheckRadius + radOffset);
        origin = enemy.AttackCheck.position;
        Vector2 newPos = new Vector2(enemy.AttackCheck.position.x + xOffset * enemy.EntityDir, enemy.AttackCheck.position.y);
        enemy.SetAttackCheckPosition(newPos);
    }

    public override void Exit()
    {
        base.Exit();
        enemy.SetAttackCheckRadius(enemy.AttackCheckRadius - radOffset);
        enemy.SetAttackCheckPosition(origin);
    }

    public override void Update()
    {
        base.Update();
    }
}
