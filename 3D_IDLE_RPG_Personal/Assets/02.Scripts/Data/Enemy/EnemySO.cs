using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Characters/Enemy")]
public class EnemySO : ScriptableObject
{
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }

    // �� ���� ������
    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; }
    [field: SerializeField][field: Range(0f, 10f)] public int Damage { get; private set; }
    [field: SerializeField][field: Range(-10f, 10f)] public float Force { get; private set; }

    // ���� ������
    [field: SerializeField] public float PlayerChasingRange {get; private set; } // ��������
    [field: SerializeField] public float AttackRange { get; private set; } // ���� ����

    [field: SerializeField][field: Range(0, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField][field: Range(0, 1f)] public float Dealing_End_TransitionTime { get; private set; }
}

