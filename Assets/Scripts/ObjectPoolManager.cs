using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : Singleton<ObjectPoolManager>
{
    

    [SerializeField] private GameObject _cubePrefab;
    private IObjectPool<GameObject> _cubePool;

    protected override void Awake()
    {
        base.Awake();
        _cubePool = new ObjectPool<GameObject>(
                createFunc: () => Instantiate(_cubePrefab),
                actionOnGet: (obj) => obj.SetActive(true),
                actionOnRelease: (obj) => obj.SetActive(false),
                actionOnDestroy: (obj) => Destroy(obj),
                collectionCheck: false,
                defaultCapacity: 10,
                maxSize: 100
                );

    }

    public GameObject GetCubeFromPool()
    {
        GameObject cube = _cubePool.Get();
        cube.GetComponent<PooledObject>().SetPool(_cubePool);
        return cube;
    }
}
