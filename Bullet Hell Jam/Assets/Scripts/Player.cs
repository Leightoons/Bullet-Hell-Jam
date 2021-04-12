using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct InputStruct {
    public bool left, right, up, down;
    public float xAxis, yAxis;

    public void Update() {
        // get directional bools
        left  = Input.GetAxisRaw("Horizontal") < 0;
        right = Input.GetAxisRaw("Horizontal") > 0;
        up    = Input.GetAxisRaw("Vertical") > 0;
        down  = Input.GetAxisRaw("Vertical") < 0;
        // calculate axis values
        xAxis = ((right) ? 1 : 0) - ((left) ? 1 : 0);
        yAxis = ((up) ? 1 : 0) - ((down) ? 1 : 0);
    }
}

public class Player : MonoBehaviour {
    public float speed;


    private InputStruct _input;
    private Vector2 _velocity;

    void Start() {
        
    }

    void Update() {
        _input.Update();
        PlayerMovement();
    }

    void PlayerMovement() {
        // get normalized direction vector
        _velocity = new Vector2(_input.xAxis, _input.yAxis).normalized;
        _velocity *= speed;
        transform.Translate(_velocity * Time.deltaTime);
    }

}
