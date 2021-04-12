using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : ObjectPool<Bullet> {
    
    public override Bullet InstantiatePooledObject() {
        Bullet newBullet = base.InstantiatePooledObject();
        newBullet.parentPool = this;
        return newBullet;
    }
    
}