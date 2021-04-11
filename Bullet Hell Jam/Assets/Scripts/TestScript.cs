using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    ObjectPool<Bullet> _pool;

    void Start() {
        _pool = GetComponent<ObjectPool<Bullet>>();

        //Debug.Log("_bool is " + SingletonScriptableObject.Instance._bool);
        //Debug.Log("_float is " + SingletonScriptableObject.Instance._float);
        //Debug.Log("_int is " + SingletonScriptableObject.Instance._int);

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //
            Bullet _new = _pool.Get();
            _new.gameObject.SetActive(true);
            _new.transform.position = new Vector3(Random.Range(-7.5f,7.5f),Random.Range(-3.5f,3.5f) , 0);
        }
    }
}
