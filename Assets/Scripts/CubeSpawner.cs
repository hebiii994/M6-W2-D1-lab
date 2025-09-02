using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public KeyCode spawnKey = KeyCode.Space;
    public float returnToPoolDelay = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(spawnKey))
        {
            GameObject newCube = ObjectPoolManager.Instance.GetCubeFromPool();
            newCube.transform.position = new Vector3(Random.Range(-5f, 5f), Random.Range(1f, 5f), Random.Range(-5f, 5f));
            newCube.GetComponent<PooledObject>().ReleaseAfter(returnToPoolDelay);
        }
    }
}
