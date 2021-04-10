using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A type-safe, generic object pool. This object pool requires you to derive a class from it,
/// and specify the type of object to pool.
/// </summary>
/// <typeparam name="T"></typeparam>
public class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour {
    [Tooltip("Prefab for this object pool")]
    public T m_prefab;

    [Tooltip("Size of this object pool")]
    public int m_size;

    private Queue<T> m_freeList;

    public void Awake() {
        m_freeList = new Queue<T>();

        // Instantiate the pooled objects and disable them.
        for (var i = 0; i < m_size; i++) {
            T _new = InstantiatePooledObject();
        }
    }

    /// <summary>
    /// Returns an object from the pool. Returns null if there are no more objects free in the pool.
    /// </summary>
    /// <returns>Object of type T from the pool.</returns>
    public virtual T InstantiatePooledObject() {
        var pooledObject = Instantiate(m_prefab, transform);
        pooledObject.gameObject.SetActive(false);
        m_freeList.Enqueue(pooledObject);
        return pooledObject;
    }


    /// <summary>
    /// Returns an object from the pool. Returns null if there are no more objects free in the pool.
    /// </summary>
    /// <returns>Object of type T from the pool.</returns>
    public T Get() {
        //var numFree = m_freeList.Count;
        //if (numFree <= 0)
        //   return null;

        // Pull an object from the end of the free list.
        var pooledObject = m_freeList.Dequeue();
        return pooledObject;
    }

    /// <summary>
    /// Returns an object to the pool. The object must have been created by this ObjectPool.
    /// </summary>
    /// <param name="pooledObject">Object previously obtained from this ObjectPool</param>
    public void ReturnObject(T pooledObject) {
        // Put the pooled object back in the free list.
        m_freeList.Enqueue(pooledObject);

        // Reparent the pooled object to us, and disable it.
        var pooledObjectTransform = pooledObject.transform;
        pooledObjectTransform.parent = transform;
        pooledObjectTransform.localPosition = Vector3.zero;
        pooledObject.gameObject.SetActive(false);
    }
}


public class ParentPoolTag<T> : MonoBehaviour where T : MonoBehaviour {
    public ObjectPool<T> m_parentPool{ get; set; }

}