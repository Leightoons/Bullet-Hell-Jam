using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletStats")]
public class BulletStats : ScriptableObject {
    public float speed;
    public Color color;

    public float lifeTime = 2;
}
