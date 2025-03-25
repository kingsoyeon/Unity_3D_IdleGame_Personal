using System.Collections;
using System.Collections.Generic;
//using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class EnemyBaseState : IState
{
    protected EnemyStateMachine stateMachine;
    protected readonly PlayerGroundData groundData;
    public EnemyBaseState(EnemyStateMachine enemyStateMachine)
    {
        stateMachine = enemyStateMachine; // 현재 적 상태에 대한 정보를 얻고, 상태를 바꾸는 기능을 쉽게 사용하기 위함
        groundData = stateMachine.Enemy.Data.GroundData;
        //attackData = stateMachine.Player.Data.AttackData;
    }

    public virtual void Enter()
    {
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpate()
    {
    }

    public virtual void Update()
    {
        // Move();
    }

    protected void StartAnimation(int hash)
    {
        // hash에 해당하는 애니메이션 시작
        stateMachine.Enemy.animator.SetBool(hash, true);
    }

    protected void StopAnimation(int hash)
    {
        // hash에 해당하는 애니메이션 끝
        stateMachine.Enemy.animator.SetBool(hash, false);
    }
    

    protected bool isInChasingRange() // 플레이어가 추적 범위 안에 있는지
    {
        if (stateMachine.target.IsDie) { return false; }
        float playerDistanceSqr = (stateMachine.target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Enemy.Data.PlayerChasingRange * stateMachine.Enemy.Data.PlayerChasingRange;
    }
}
