using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A type-safe, generic object pool. This object pool requires you to derive a class from it,
/// and specify the type of object to pool.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour {
    #region // Class variables //

    [Tooltip("Prefab for this object pool")]
    //[SerializeField]
    public T _prefab;

    [Tooltip("Initial size of this object pool")]
    [SerializeField]
    private int _size;

    [HideInInspector]
    public GameObject _poolParent;

    private Queue<T> _poolQueue;

    #endregion

    public void Awake() {
        // create parent object to store pooled objects, name it after pooled object type and number it
        _poolParent = new GameObject(typeof(T).ToString() + " Pool "+ GameObject.FindGameObjectsWithTag("Pool Parent").Length);
        _poolParent.tag = "Pool Parent";
        // create pool queue
        _poolQueue = new Queue<T>();
        // Instantiate the pooled objects and disable them.
        for (var i = 0; i < _size; i++) {
            //T newInst = InstantiatePooledObject();
        }
    }

    /// <summary>
    /// Creates a new gameObject and adds it to the pool.
    /// Can be overridden in sub-classes to specify what to do with each new object directly following instantiation.
    /// </summary>
    /// <returns>Newly created object of type T from the pool.</returns>
    public virtual T InstantiatePooledObject() {
        var pooledObject = Instantiate(_prefab, transform);
        pooledObject.gameObject.SetActive(false);
        pooledObject.transform.parent = _poolParent.transform;
        _poolQueue.Enqueue(pooledObject);
        return pooledObject;
    }

    /// <summary>
    /// Returns an object from the pool. If pool is empty, a new object of type T will be instantiated
    /// </summary>
    /// <returns>Object of type T from the pool.</returns>
    public T Get() {
        if (_poolQueue.Count <= 0) {
            //Debug.Log("Pool empty: Instantiating new object into pool");
            InstantiatePooledObject();
        }
        // Pull an object from the queue.
        var pooledObject = _poolQueue.Dequeue();
        return pooledObject;
    }

    /// <summary>
    /// Returns an object to the pool. The object must have been created by this ObjectPool.
    /// </summary>
    /// <param name="pooledObject">Object previously obtained from this ObjectPool</param>
    public void ReturnObject(T pooledObject) {
        // Put the pooled object back into the queue.
        _poolQueue.Enqueue(pooledObject);

        // Reparent the pooled object to us, and disable it.
        //var pooledObjectTransform = pooledObject.transform;
        //pooledObjectTransform.parent = transform;
        //pooledObjectTransform.localPosition = Vector3.zero;
        pooledObject.gameObject.SetActive(false);
    }
}