using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShootType : ShootType
{
    public override void Fire()
    {
        if (timer > ShootingTimer) {
            EnemyBullet e = Instantiate(eb, transform.position, transform.rotation);
            e.setBulletDirection(new Vector2(1, 0));
            timer = 0;
        }
    }
}
