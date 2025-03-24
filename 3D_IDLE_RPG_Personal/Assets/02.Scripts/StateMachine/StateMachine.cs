using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // 필요한 것, 1. 입력 들어오고 2. 들어오고 3. 업데이트 4. 물리업데이트 5. 빠져나가고
    public void Enter();
    public void Exit();
    public void HandleInput();
    public void Update();
    public void PhysicsUpate();
}

public abstract class StateMachine
{
    protected IState currentState;


    public void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void HandleInput()
    {
        currentState?.HandleInput();
    }

    public void Update()
    {
        currentState?.Update();
    }

    public void PhysicsUpdate()
    {
        currentState?.PhysicsUpate();
    }
}
