using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    ObjectPool<Bullet> _pool;

    void Start() {
        _pool = GetComponent<ObjectPool<Bullet>>();

        StartCoroutine(TestCoroutine());
    }

    IEnumerator TestCoroutine() {
        Bullet[] bList = Bullet.FindObjectsOfType<Bullet>();
        while (bList.Length + 1 < 5) {
            bList = Bullet.FindObjectsOfType<Bullet>();
            NewBullet();
            print("Added new bullet; " + (5 - (bList.Length + 1)) + " until 5 total");
            yield return new WaitForSeconds(1.5f);
        }
        print("Coroutine finished");
        yield return null;
    }

    void NewBullet() {
        Bullet _new = _pool.Get();
        _new.gameObject.SetActive(true);
        _new.transform.position = new Vector3(Random.Range(-7.5f, 7.5f), Random.Range(-3.5f, 3.5f), 0);
    }


    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            NewBullet();
        }
    }
}
