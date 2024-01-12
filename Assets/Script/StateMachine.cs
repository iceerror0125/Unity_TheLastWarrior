
using UnityEngine;

public class StateMachine 
{
    public BaseState currentState { get; private set; }
    public void InitState(BaseState newState)
    {
        currentState = newState;
        currentState.Enter();
    }

    public void ChangeState(BaseState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
