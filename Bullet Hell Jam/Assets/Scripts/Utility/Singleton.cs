using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour {

    public static Singleton Instance { get; private set; }

    virtual protected void Awake() {
        // Instantiate singleton
        if (Instance == null) {
            Instance = this;
        }
        // If an instance already exists
        else {
            Debug.LogWarning("Attempted to instantiate multiple instances of singleton class at "+this,this.gameObject);
            Debug.LogWarning("Singleton class already instantiated in " + Instance, Instance.gameObject);
            Destroy(this);
        }
    }
}

public class TestSingleton : Singleton {
    public  bool _pubvar = true;
    private bool _privar = true;

    protected override void Awake() {
        base.Awake();
        Debug.Log("public var = " + _privar + "; private var = " + _privar);

    }
}