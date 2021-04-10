using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTestScript : MonoBehaviour
{

    public List<TestSingleton> ClassList;

    // Start is called before the first frame update
    void Start() {
        ClassList = new List<TestSingleton>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            TestSingleton _new = gameObject.AddComponent<TestSingleton>();
        }
    }
}
