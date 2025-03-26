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
        stateMachine = enemyStateMachine; // ���� �� ���¿� ���� ������ ���, ���¸� �ٲٴ� ����� ���� ����ϱ� ����
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
        Move();
    }

    protected void StartAnimation(int hash)
    {
        // hash�� �ش��ϴ� �ִϸ��̼� ����
        stateMachine.Enemy.animator.SetBool(hash, true);
    }

    protected void StopAnimation(int hash)
    {
        // hash�� �ش��ϴ� �ִϸ��̼� ��
        stateMachine.Enemy.animator.SetBool(hash, false);
    }

    private void Move()
    {
        Vector3 movementDirection = GetMovementDirection();

        Rotate(movementDirection);

        Move(movementDirection);
    }

    private Vector3 GetMovementDirection()
    {
        Vector3 dir = (stateMachine.target.transform.position - stateMachine.Enemy.transform.position).normalized;
        return dir;
    }

    void Move(Vector3 movementDirection)
    {
        float movementSpeed = GetMovementSpeed();
        stateMachine.Enemy.CharacterController.Move(((movementDirection * movementSpeed) * Time.deltaTime));
    }

    private float GetMovementSpeed()
    {
        float movementSpeed = stateMachine.MovementSpeed * stateMachine.MovementSpeedModifier;
        return movementSpeed;
    }

    void Rotate(Vector3 movementDirection)
    {
        if (movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(movementDirection);
            stateMachine.Enemy.transform.rotation = Quaternion.Lerp(stateMachine.Enemy.transform.rotation, targetRotation, stateMachine.RotationDamping * Time.deltaTime);
        }
    }

    protected bool isInChasingRange() // �÷��̾ ���� ���� �ȿ� �ִ���
    {
        if (stateMachine.target.IsDie) { return false; }
        float playerDistanceSqr = (stateMachine.target.transform.position - stateMachine.Enemy.transform.position).sqrMagnitude;
        return playerDistanceSqr <= stateMachine.Enemy.Data.PlayerChasingRange * stateMachine.Enemy.Data.PlayerChasingRange;
    }

    protected float GetNormalizedTime(Animator animator, string tag)
    {
        AnimatorStateInfo currentInfo = animator.GetCurrentAnimatorStateInfo(0); // ���� ���� ���� �ִϸ��̼� ����
        AnimatorStateInfo nextInfo = animator.GetNextAnimatorStateInfo(0); // ������ ���� ������ �ִϸ��̼� ����

        // �ִϸ��̼��� ��ȯ �� && ���� �ִϸ��̼� �±� üũ
        if (animator.IsInTransition(0) && nextInfo.IsTag(tag))
        {
            return nextInfo.normalizedTime;
        }
        // �ִϸ��̼��� ��ȯ �� �ƴ� && ���� �ִϸ��̼� �±� üũ
        else if (!animator.IsInTransition(0) && currentInfo.IsTag(tag))
        {
            return currentInfo.normalizedTime;
        }
        else
        {
            return 0f;
        }
    }
}
