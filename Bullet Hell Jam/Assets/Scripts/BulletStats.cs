using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletStats")]
public class BulletStats : ScriptableObject {

    public Color  color;
    public Sprite image;
    public float  imageScale = 1f;

    public float speed;

    public float lifeTime = 2;
}
