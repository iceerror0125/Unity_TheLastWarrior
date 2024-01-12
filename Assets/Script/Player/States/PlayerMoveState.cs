

using UnityEngine;

public class PlayerMoveState : PlayerGroundState
{
    public PlayerMoveState(string animName) : base(animName)
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
        
        MoveController(player.MoveSpeed);

        Debug.Log("Move");
        if (player.MoveDir == 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
