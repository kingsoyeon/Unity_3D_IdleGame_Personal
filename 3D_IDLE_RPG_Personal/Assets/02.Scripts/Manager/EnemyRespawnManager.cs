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
            StopCoroutine(spawnCoroutine);
        }
        spawnCoroutine = StartCoroutine(RandomSpawn());
    }

    public IEnumerator RandomSpawn()
    {
        
        yield return new WaitForSeconds(10);

        float z =  UnityEngine.Random.Range(40,60);
        Vector3 spawnPosition = playerTransform.position + Vector3.forward * z;
        Debug.Log(spawnPosition);
        GameObject enemy = GetPool(2, spawnPosition);

        Health target= enemy.GetComponent<Health>();
        OnEnemySpawn?.Invoke(target);

        target.OnDie += () => ReturnPool(enemy);
    }
    
    private GameObject GetPool(int prefabIndex, Vector3 spawnPosition )
    {
        GameObject enemyPool = objectPoolManager.GetObject(prefabIndex, spawnPosition, Quaternion.identity);

        return enemyPool;
    }

    public void ReturnPool(GameObject enemy)
    {
        enemy.transform.position = Vector3.zero;
        enemy.transform.rotation = Quaternion.identity;
        objectPoolManager.ReturnObject(2, enemy);
    }
}
