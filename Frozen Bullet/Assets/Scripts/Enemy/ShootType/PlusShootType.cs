using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusShootType : ShootType
{
    public override void Fire()
    {
        if (timer > ShootingTimer) {
            EnemyBullet a = Instantiate(eb, transform.position, transform.rotation);
            a.setBulletDirection(new Vector2(-1, 0));

            EnemyBullet b = Instantiate(eb, transform.position, transform.rotation);
            b.setBulletDirection(new Vector2(1, 0));

            EnemyBullet c = Instantiate(eb, transform.position, transform.rotation);
            c.setBulletDirection(new Vector2(0, -1));

            EnemyBullet d = Instantiate(eb, transform.position, transform.rotation);
            d.setBulletDirection(new Vector2(0, 1));
            timer = 0;
        }
    }

}
