using System.Xml;
using UnityEngine;

public class EnemyState : BaseState
{
    protected Enemy enemy;
    public EnemyState(Enemy enemy, string animName) : base(animName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateMachine = enemy.stateMachine;
        enemy.anim.Play(animName);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (enemy.stat.Hp <= 0 && !enemy.isInDeadState)
        {
            stateMachine.ChangeState(enemy.deadState);
        }
    }
}
