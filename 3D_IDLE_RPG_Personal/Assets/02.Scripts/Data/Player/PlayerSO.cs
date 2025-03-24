using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerGroundData 
{
    [field: SerializeField][field: Range(0f, 25f)] public float BaseSpeed { get; private set; } = 5f;
    [field: SerializeField][field: Range(0f, 25f)] public float BaseRotationDamping { get; private set; } = 1f;

    [field: Header("IdleData")]

    [field: Header("WalkData")]
    [field: SerializeField][field: Range(0f, 2f)] public float WalkSpeedModifier { get; private set; } = 0.225f;

    [field: Header("RunData")]
    [field: SerializeField][field: Range(0f, 2f)] public float RunSpeedModifier { get; private set; } = 1f;

}
[Serializable]
public class PlayerAirData 
{
    [field: Header("JumpData")]
    [field: SerializeField][field: Range(0f, 25f)] public float JumpForce { get; private set; } = 5f;
}
[Serializable]
public class PlayerAttackData 
{
    [field: Header("AttackData")]
    [field: SerializeField] public List<PlayerAttackInfoData> AttackInfoDatas { get; private set; }
    public int GetAttackInfoCount() { return AttackInfoDatas.Count; } // 공격에 대한 정보 개수만큼 카운트로 반환
    public PlayerAttackInfoData GetAttackInfoData(int index) {return AttackInfoDatas[index];}
}

[Serializable]
public class PlayerAttackInfoData 
{
    [field: Header("AttackData")]
    [field: SerializeField]public string AttackName { get; private set; }
    [field: SerializeField]public int ComboStateIndex { get; private set; }
    [field: SerializeField][field: Range(0f, 1f)] public float ComboTransitionTime { get; private set; } // 콤보 가능한 시간 범위
    [field: SerializeField][field: Range(0f, 3f)] public float ForceTransitionTime { get; private set; } // 댐핑 가능한 시간 범위

    [field: SerializeField][field: Range(-10f, 10f)] public float Force{ get; private set; } // 힘을 얼마만큼 줄 건지

    [field: SerializeField][field: Range(0f, 10f)] public float Damage { get; private set; } // 데미지
    [field: SerializeField][field: Range(0, 1f)] public float Dealing_Start_TransitionTime { get; private set; }
    [field: SerializeField][field: Range(0, 1f)] public float Dealing_End_TransitionTime { get; private set; }




}

[CreateAssetMenu(fileName = "Player", menuName = "Characters/Player")]
public class PlayerSO : ScriptableObject
{
    // player상태데이터들을 담아준다
    [field: SerializeField] public PlayerGroundData GroundData { get; private set; }
    [field: SerializeField] public PlayerAirData AirData { get; private set; }
    [field: SerializeField] public PlayerAttackData AttackData { get; private set; }
}
    

