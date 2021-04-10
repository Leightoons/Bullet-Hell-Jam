using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool<Bullet> {

    public override Bullet InstantiatePooledObject() {
        Bullet _new = base.InstantiatePooledObject();
        _new.parentPool = this;
        return _new;
    }

}
