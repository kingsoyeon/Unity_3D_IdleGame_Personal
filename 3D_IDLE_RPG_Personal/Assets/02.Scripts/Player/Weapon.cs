using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider myCollider;

    private int damage;
    //private float Knockback; �˹� ���� ��

    private List<Collider> alreadyCollider = new List<Collider>(); // �� �ݶ��̴��� �浹�� �ٸ� �ݶ��̴� ����Ʈ 
    void Start()
    {
        alreadyCollider.Clear(); // �ʱ�ȭ
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollider) return; // ���ݶ��̴��� �ε����� ����
        if (alreadyCollider.Contains(other)) return; // �̹� �ε����� �ݶ��̴��� �ε����� ����

        // �Ѵ� �ƴ϶�� ����Ʈ�� �־��ش�
        alreadyCollider.Add(other);

        // health ������Ʈ�� �����ٸ�, ��������ŭ take damage�� ȣ���Ѵ�
        if (other.TryGetComponent(out Health health))
        {
            health.TakeDamage(damage);
        }

        // �˹� ���� �� 
        //if(other.TryGetComponent(out ForceReciever force))
        //{

        //}

    }

    // �ܺο��� ������ �� �ʿ�
    // �˹� �߰� �� �̰��� �߰�
    public void SetAttack(int damage)
    {
        this.damage = damage;
    }
}
