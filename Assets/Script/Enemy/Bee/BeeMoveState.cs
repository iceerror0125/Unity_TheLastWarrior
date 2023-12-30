using UnityEngine;

public class BeeMoveState : BeeState
{
    Vector2 moveVector;
    public BeeMoveState(string _animName)
    {
        animName = _animName;
    }
    public override void Enter()
    {
        base.Enter();
        timer = bee.MoveDuration();

        moveVector = CalculateMoveVector();
    }
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        bee.ChangeVelocity(bee.MoveSpeed() * moveVector.x, moveVector.y);
        if (timer < 0)
        {
            bee.idleState.SetHasFlip(true);
            stateMachine.ChangeState(bee.idleState);
        }
    }
    private Vector2 CalculateMoveVector()
    {
        float x = Random.Range(0, bee.MoveRange.x);
        if (bee.EntityDir() < 0)
        {
            x *= -1; 
        }
        
        float y = Random.Range(-bee.MoveRange.y, bee.MoveRange.y);
        return new Vector2(x, y);
    }
}
