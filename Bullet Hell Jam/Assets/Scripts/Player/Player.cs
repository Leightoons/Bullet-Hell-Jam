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
    [SerializeReference]
    private GameObject hitBox;


    private InputStruct _input;
    private Vector2 _velocity;
    //
    private bool isFocused;
    //
    [SerializeField]
    private float fireCooldown;
    private float _fireCooldownTimer = 0f;
    //
    private PlayerBulletPool _bulletPool;
    //
    [HideInInspector]
    public BoxCollider2D _hitBox;
    private SpriteRenderer _hitboxSprite;
    private const float _hitboxOpacityDefault = .3f;
    private const float _hitboxOpacityFocus   = .75f;


    void Start() {
        _hitboxSprite = hitBox.GetComponent<SpriteRenderer>();
        _hitBox = hitBox.GetComponent<BoxCollider2D>();
        _bulletPool = GetComponent<PlayerBulletPool>(); // get bullet pool component
    }

    void Update() {
        _input.Update();
        HandleFocusInput();
        //
        float moveSpeed;
        Color col = _hitboxSprite.color;
        if (isFocused) {
            moveSpeed = moveSpeedFocus;
            _hitboxSprite.color = new Color(col.r, col.g, col.b, _hitboxOpacityFocus);
        }
        else {
            moveSpeed = moveSpeedDefault;
            _hitboxSprite.color = new Color(col.r, col.g, col.b, _hitboxOpacityDefault);
        }
        //
        PlayerMovement(moveSpeed);
        HandlePlayerFire();
    }

    void PlayerMovement(float speed) {
        // get normalized direction vector
        _velocity = new Vector2(_input.xAxis, _input.yAxis).normalized;
        _velocity *= speed;
        transform.Translate(_velocity * Time.deltaTime);
    }

    void HandleFocusInput() {
        if (_input.focus) isFocused = true;
        else isFocused = false;
    }

    #region Firing
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
    #endregion
}
