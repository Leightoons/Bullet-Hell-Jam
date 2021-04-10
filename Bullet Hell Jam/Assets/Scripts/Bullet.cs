using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletStats bulletStats;

    public Vector2  velocity;
    private float lifeTimeRemaining;

    public ObjectPool<Bullet> parentPool;

    private void Start() {
        // set color
        SpriteRenderer spriteComponent = GetComponent<SpriteRenderer>();
        spriteComponent.color = bulletStats.color;
        // set lifespan
        lifeTimeRemaining = bulletStats.lifeTime;

    }

    private void Update() {

        if (lifeTimeRemaining >= 0) {
            lifeTimeRemaining -= Time.deltaTime;
        } else {
            lifeTimeRemaining = bulletStats.lifeTime;
            parentPool.ReturnObject(this);
        }
    }

}
