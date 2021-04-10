using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Vector2  velocity;
    public float    acceleration;

    public ObjectPool<Bullet> parentPool;
    private float lifeTime = 2;
    private const float maxLife = 2;

    private void Update() {

        if (lifeTime >= 0) {
            lifeTime -= Time.deltaTime;
        } else {
            lifeTime = maxLife;
            parentPool.ReturnObject(this);
        }
    }

}
