using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Template for a singleton scriptable object. This ScriptableObject should not be derived from,
/// but rather copy/pasted into a new #C script and modified. An instance must be placed within Assets/Resources
/// </summary>

[CreateAssetMenu( menuName = "SingletonScriptableObject")]
public class SingletonScriptableObject : ScriptableObject {

    private static SingletonScriptableObject _instance;
    public static SingletonScriptableObject Instance {
        get {
            if (_instance == null) {
                // load scriptableObject from project files
                // "test" is file path name relative to Resources folder
                // Example: the full path for "test" is "Assets/Resources/test"
                _instance = Resources.Load<SingletonScriptableObject>("test");
            }
            return _instance;
        }
    }

    public bool  _bool  = true;
    public float _float = 0.5f;
    public int   _int   = 4;
}
