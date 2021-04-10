using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    public Queue<GameObject> _pool;
    [SerializeField]
    public GameObject _obj;
    [SerializeField]
    public int _poolSize;

    public void InitPool(int poolSize) {
        _pool = new Queue<GameObject>();

        GameObject _new;
        for (int i = 0; i < poolSize; i++) {
            _new = Instantiate<GameObject>(_obj);
            _pool.Enqueue(_new);
        }

    }

    public GameObject GetFromPool() {
        GameObject newObject = _pool.Dequeue();
        newObject.SetActive(true);
        return newObject;
    }

    public void ReturnToPool(GameObject _obj) {
        _obj.SetActive(false);
        _pool.Enqueue(_obj);
    }

}
