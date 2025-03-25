using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private Dictionary<int, Queue<GameObject>> pools = new Dictionary<int, Queue<GameObject>>();
    public static ObjectPoolManager Instance { get; private set; }

    void Awake()
    {
        Instance = this;

        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new Queue<GameObject>();
        }
    }

    public GameObject GetObject(int prefabIndex, Vector3 position, Quaternion rotation)
    {
        if(!pools.ContainsKey(prefabIndex)) return null;

        GameObject go;
        if (pools[prefabIndex].Count > 0)
        {
            go = pools[prefabIndex].Dequeue();
        }
        else
        {
            go = Instantiate(prefabs[prefabIndex]);
            go.GetComponent<IPoolable>()?.Initialize(go => ReturnObject(prefabIndex, go));
        }
        
        go.transform.SetPositionAndRotation(position, rotation);
        go.SetActive(true);
        go.GetComponent<IPoolable>()?.OnSpawn();
        return go;
    }

    public void ReturnObject(int prefabIndex, GameObject gameObj)
    {
        if (!pools.ContainsKey(prefabIndex)) { Destroy(gameObj);  return; }
        gameObj.SetActive(false);
        pools[prefabIndex].Enqueue(gameObject);
    }
}
