using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    // �ʿ��� ��, 1. �Է� ������ 2. ������ 3. ������Ʈ 4. ����������Ʈ 5. ����������
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
