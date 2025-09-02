using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class PooledObject : MonoBehaviour
{
    private IObjectPool<GameObject> _pool;
    public void SetPool(IObjectPool<GameObject> pool)
    {
        _pool = pool;
    }
    public void ReleaseAfter(float seconds)
    {
        StartCoroutine(ReleaseRoutine(seconds));
    }

    private IEnumerator ReleaseRoutine(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _pool.Release(this.gameObject);
    }
}
