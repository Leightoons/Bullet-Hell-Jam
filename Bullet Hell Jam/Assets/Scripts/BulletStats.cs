using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletStats")]
public class BulletStats : ScriptableObject {
    public float _speed;
    public Color _color;

    public float lifeTime = 2;
}
