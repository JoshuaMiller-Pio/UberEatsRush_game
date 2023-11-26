using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = FindObjectOfType<T>();

            if (_instance != null) return _instance;

            GameObject inheratedobj = new GameObject();

            _instance = inheratedobj.AddComponent<T>();

            inheratedobj.name = $"{typeof(T)} - [Singleton]";

            DontDestroyOnLoad(inheratedobj);

            return _instance;


        }

    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}