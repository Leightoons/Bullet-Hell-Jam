using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InputStruct {
    public bool left, right, up, down;
    public float xAxis, yAxis;
    public bool fire;
    public bool focus;

    public void Update() {
        // get directional bools
        left  = Input.GetAxisRaw("Horizontal") < 0;
        right = Input.GetAxisRaw("Horizontal") > 0;
        up    = Input.GetAxisRaw("Vertical") > 0;
        down  = Input.GetAxisRaw("Vertical") < 0;
        // calculate axis values
        xAxis = ((right) ? 1 : 0) - ((left) ? 1 : 0);
        yAxis = ((up) ? 1 : 0) - ((down) ? 1 : 0);
        // get button states
        fire  = Input.GetButton("Fire");
        focus = Input.GetButton("Focus");
    }
}

public class Player : MonoBehaviour {

    public float moveSpeedDefault;
    public float moveSpeedFocus;
    //
    public BoxCollider2D hitBox;


    private InputStruct _input;
    private Vector2 _velocity;
    //
    [SerializeField]
    private float fireCooldown;
    private float _fireCooldownTimer = 0f;
    //
    private PlayerBulletPool _bulletPool;
    

    void Start() {
        _bulletPool = GetComponent<PlayerBulletPool>();
    }

    void Update() {
        _input.Update();
        PlayerMovement();
        HandlePlayerFire();
    }

    void PlayerMovement() {
        // get normalized direction vector
        _velocity = new Vector2(_input.xAxis, _input.yAxis).normalized;
        _velocity *= moveSpeedDefault;
        transform.Translate(_velocity * Time.deltaTime);
    }

    void HandlePlayerFire() {
        // increment cooldown
        if (_fireCooldownTimer > 0) _fireCooldownTimer -= Time.deltaTime;
        if (_input.fire) {
            OnFireHeld();
        }
    }

    void OnFireHeld() {
        if (_fireCooldownTimer <= 0) {
            FireProjectile();
        }
    }

    void FireProjectile() {
        _fireCooldownTimer = fireCooldown;
        Bullet newBullet = _bulletPool.Get();
        newBullet.transform.position = transform.position;
        newBullet.gameObject.SetActive(true);
        newBullet.BulletInit(0);
    }
}
