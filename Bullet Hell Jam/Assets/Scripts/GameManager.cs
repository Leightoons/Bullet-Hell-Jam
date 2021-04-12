using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class GameManager : Singleton {

    [Header("Player")]
    public GameObject player; // prefab for player object

    //[Header("GameObjects")]
    // game objects go here

    //[Header("UI")]
    // UI related shit goes here

    [Header("Camera")]
    public CameraHandler camera;
    public static float AspectRatio { get { return Camera.main.aspect; } }
    public static float CameraScale { get { return Camera.main.orthographicSize; } }


    //[Header("Misc")]
    // audio handling script goes here




    private GameObject _player; //Local instance of player object


    void Start() {
        
    }
}
