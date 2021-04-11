using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public BulletStats bulletStats;

    public Vector2  _velocity;
    public float    _angleDirection;
    private float   _lifeTimeRemaining;

    public ObjectPool<Bullet> parentPool;

    private void Start() {
        // set color
        SpriteRenderer spriteComponent = GetComponent<SpriteRenderer>();
        spriteComponent.color = bulletStats.color;
        spriteComponent.sprite = bulletStats.image;
        spriteComponent.size = bulletStats.imageScale * Vector2.one;

    }

    private void Update() {
        // update position
        transform.Translate(_velocity * Time.deltaTime, Space.World);

        // Return to pool on lifetime end
        if (_lifeTimeRemaining >= 0) {
            _lifeTimeRemaining -= Time.deltaTime;
        } else {
            _lifeTimeRemaining = bulletStats.lifeTime;
            parentPool.ReturnObject(this);
        }

        // Return to pool if too far from screen
        if (Mathf.Abs(transform.position.x) > GameInfo.aspectRatio * Camera.main.orthographicSize * 2
            || Mathf.Abs(transform.position.y) > Camera.main.orthographicSize * 2)
             {
            _lifeTimeRemaining = bulletStats.lifeTime;
            parentPool.ReturnObject(this);
        }

    }

    public void BulletInit(float angle) {
        // set lifespan
        _lifeTimeRemaining = bulletStats.lifeTime;
        // set velocity
        _angleDirection = angle;
        transform.eulerAngles = Vector3.forward * angle;
        _velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        _velocity *= bulletStats.speed;
    }

}
