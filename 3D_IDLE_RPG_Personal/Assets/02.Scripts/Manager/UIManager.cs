using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    ObjectPoolManager objectPoolManager;

    private void Start()
    {
        objectPoolManager = ObjectPoolManager.Instance;
    }
}
