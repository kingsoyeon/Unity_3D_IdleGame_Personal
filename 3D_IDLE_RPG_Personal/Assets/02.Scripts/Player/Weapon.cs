using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    //private float Knockback; 넉백 구현 시

    private List<Collider> alreadyCollider = new List<Collider>(); // 이 콜라이더와 충돌된 다른 콜라이더 리스트 
    void Start()
    {
        alreadyCollider.Clear(); // 초기화
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return; // 내콜라이더랑 부딪히면 리턴
        if (alreadyCollider.Contains(other)) return; // 이미 부딪혔던 콜라이더랑 부딪히면 리턴

        // 둘다 아니라면 리스트에 넣어준다
        alreadyCollider.Add(other);

        // health 컴포넌트를 가졌다면, 데미지만큼 take damage를 호출한다
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }

        // 넉백 구현 시 
        //if(other.TryGetComponent(out ForceReciever force))
        //{

        //}

    }

    // 외부에서 세팅할 때 필요
    // 넉백 추가 시 이곳에 추가
    public void SetAttack(int damage)
    {
        this.damage = damage;
    }
}
