using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShootType : ShootType
{
    public override void Fire()
    {
        if (timer > ShootingTimer)
        {

            for (float i = -1; i <= 1; i+=0.25f)
            {
                for (float j = -1; j <= 1; j += 0.25f)
                {
                    if (i == 0&& j == 0) {
                        continue;
                    }
                    EnemyBullet a = Instantiate(eb, transform.position, transform.rotation);
                    a.setBulletDirection(new Vector2(i, j));

                }
            }

            timer = 0;
        }
    }
}
