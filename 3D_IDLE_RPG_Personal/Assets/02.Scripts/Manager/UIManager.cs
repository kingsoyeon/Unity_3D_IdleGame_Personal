using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;



public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    public ObjectPoolManager objectPoolManager;
    
    [SerializeField] private GameObject[] UIPrefabs;

    private Dictionary<int, GameObject> UIPrefabsDictionary = new Dictionary<int, GameObject>();

    private void Awake()
    {
        if(Instance ==null) Instance = this;
        else Destroy(gameObject);

    }
    private void Start()
    {
        objectPoolManager = ObjectPoolManager.Instance;

        // ui를 오브젝트풀로 한 번만 생성하고, 활성화<->비활성화한다
        for (int i = 0; i < UIPrefabs.Length; i++)
        {
            GameObject uiPool = GetPool(i);
            UIPrefabsDictionary[i] = uiPool;
        }

        UIPrefabsDictionary[1].SetActive(false);
    }

    private GameObject GetPool(int prefabIndex)
    {
        GameObject uiPool = objectPoolManager.GetObject(prefabIndex, Vector3.zero, Quaternion.identity);

        return uiPool;
    }

    public void ToggleUI(int index)
    {
        if (UIPrefabsDictionary.ContainsKey(index))
        {
            GameObject ui = UIPrefabsDictionary[index];
            IUI uiInterface = ui.GetComponent<IUI>();

            if (uiInterface != null)
            {
                uiInterface.Toggle();
            }
        }
    }
}
