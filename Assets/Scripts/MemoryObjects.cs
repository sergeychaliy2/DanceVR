using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class MemoryObjectEntry
{
    public string key;
    public Object value;
}

public class MemoryObjects : MonoBehaviour
{
    private static MemoryObjects _instance;

    public static MemoryObjects Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MemoryObjects>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<MemoryObjects>();
                    singletonObject.name = typeof(MemoryObjects).ToString() + " (Singleton)";
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private List<MemoryObjectEntry> memoryObjects = new List<MemoryObjectEntry>();

    private Dictionary<string, Object> objectsDictionary = new Dictionary<string, Object>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeDictionary();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeDictionary()
    {
        objectsDictionary.Clear();
        foreach (var entry in memoryObjects)
        {
            if (!objectsDictionary.ContainsKey(entry.key))
            {
                objectsDictionary.Add(entry.key, entry.value);
            }
            else
            {
                ErrorType.UnknownError.LogCustomError("Duplicate key found in memoryObjects: " + entry.key);
            }
        }
    }

    public T GetObject<T>(string key) where T : Object
    {
        if (objectsDictionary.TryGetValue(key, out Object obj))
        {
            return obj as T;
        }
        else
        {
            ErrorType.UnknownError.LogCustomError("Object with key " + key + " not found.");
            return null;
        }
    }
}
