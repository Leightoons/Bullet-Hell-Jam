using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    ObjectPool _pool;

    void Start() {
        _pool = GetComponent<ObjectPool>();
        _pool.InitPool(_pool._poolSize);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //
        }
    }
}
