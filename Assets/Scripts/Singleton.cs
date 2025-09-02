using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    private static bool _isApplicationQuitting = false;

    public static T Instance
    {
        get
        {
            if (_isApplicationQuitting)
            {
                Debug.LogWarning($"[Singleton] L'instanza '{typeof(T)}' è già stata distrutta");
                return null;              
            }
            if (_instance == null)
            {
                _instance = FindAnyObjectByType<T>(FindObjectsInactive.Include);
                if (_instance != null )
                {
                    Debug.Log($"[Singleton] Creazione di un'istanza di {typeof(T)} perché non esiste.");
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<T>();
                    singletonObject.name = typeof(T).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if ( _instance == null )
        {
            _instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this )
        {
            Debug.LogWarning($"[Singleton] Esiste già un'istanza di {typeof(T)}. Distruggo il duplicato ({this.gameObject.name}).");
            Destroy(gameObject);
        }
    }

    protected virtual void OnApplicationQuit()
    {
        _isApplicationQuitting = true;
    }
}
