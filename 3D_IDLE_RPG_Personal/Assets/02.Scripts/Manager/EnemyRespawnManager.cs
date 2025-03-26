using System;
using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawnManager : MonoBehaviour
{
    public static EnemyRespawnManager Instance { get; private set; }
    public ObjectPoolManager objectPoolManager;

    public event Action<Health> OnEnemySpawn;
    public Transform playerTransform;

    private Coroutine spawnCoroutine;    
    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    void Start()
    {
        objectPoolManager = ObjectPoolManager.Instance;

        

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) { playerTransform = player.transform; }
        
        EnemySpawn(); // enemy prefab pool

    }
    public void EnemySpawn()
    {
        if(spawnCoroutine != null)
        {
            return;
        }
        spawnCoroutine = StartCoroutine(RandomSpawn());
    }

    public IEnumerator RandomSpawn()
    {

        while (true)
        {
             
            float z = UnityEngine.Random.Range(20, 40);
            Vector3 spawnPosition = playerTransform.position + Vector3.forward * z;
            Debug.Log(spawnPosition);
            GameObject enemy = GetPool(2, spawnPosition); 
            // 맨처음, 이니셜라이즈하고 활성화해준것을 가져옴

            Health target = enemy.GetComponent<Health>();
            
            OnEnemySpawn?.Invoke(target);

            bool isDie = false;

            target.OnDie += () =>
            {
                ReturnPool(enemy);
                isDie = true;
            };
            yield return new WaitUntil(() => isDie);
        }
    }
    private GameObject GetPool(int prefabIndex, Vector3 spawnPosition )
    {
        GameObject enemyPool = objectPoolManager.GetObject(prefabIndex, spawnPosition, Quaternion.identity);
        
        return enemyPool;

    }

    public void ReturnPool(GameObject enemy)
    {
        objectPoolManager.ReturnObject(2, enemy);
    }
}
