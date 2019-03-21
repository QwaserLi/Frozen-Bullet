using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : Enemy
{
    protected override void Fire()
    {
        float y = -1;
        for (int i = 0; i < 5; i++) {
            EnemyBullet e = Instantiate(enemyBullet, transform.position, transform.rotation);
            
            if (initialPosition == EnemyPosition.Left)
            {
                e.setBulletDirection(new Vector2(1, y));
            }
            else
            {
                e.setBulletDirection(new Vector2(-1, y));

            }
            y += 0.5f;
        }
    }
}
