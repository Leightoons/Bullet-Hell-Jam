using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    // animation curve testing
    public AnimationCurve animationCurve;
    private float _curveTimeCurrent = 0f;
    private const float _curveMult = 5;

    ObjectPool<Bullet> _pool;

    private GameManager gameManager;


    void Start() {
        // animation
        _curveTimeCurrent = 0;
        gameManager = GetComponent<GameManager>();

        _pool = GetComponent<ObjectPool<Bullet>>();
        //
        //StartCoroutine(TestCoroutine());
        //
        print("ASPECT RATIO IS " + GameManager.AspectRatio);
        print("CAMERA SCALE IS " + GameManager.CameraScale);
    }

    IEnumerator TestCoroutine() {
        Bullet[] bList = Bullet.FindObjectsOfType<Bullet>();
        while (bList.Length + 1 < 5) {
            bList = Bullet.FindObjectsOfType<Bullet>();
            NewBullet();
            //print("Added new bullet; " + (5 - (bList.Length + 1)) + " until 5 total");
            yield return new WaitForSeconds(1.5f);
        }
        //print("Coroutine finished");
        yield return null;
    }

    void NewBullet() {
        Bullet _new = _pool.Get();
        _new.gameObject.SetActive(true);
        _new.transform.position = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f), 0);
        float randomAngle = Random.Range(-180, 180);
        _new.BulletInit(randomAngle);
        //print(randomAngle);
        //_new.BulletInit(90 * Mathf.Deg2Rad);
    }


    // Update is called once per frame
    void Update() {
        // animation
        _curveTimeCurrent = (_curveTimeCurrent + (Time.deltaTime*0.3f)) % 1;
        float curveVal = animationCurve.Evaluate(_curveTimeCurrent) - 0.5f;

        if (Input.GetKeyDown(KeyCode.Space)) {
            NewBullet();
        }
    }
}
