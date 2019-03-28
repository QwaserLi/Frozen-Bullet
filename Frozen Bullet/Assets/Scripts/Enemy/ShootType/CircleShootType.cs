using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShootType : ShootType
{

    float currentangle = 0;

    public override void Fire()
    {
        if (timer > ShootingTimer)
        {

            for (float i = 0; i < 20; i++)
            {
            
                EnemyBullet a = Instantiate(eb, transform.position, transform.rotation);
                a.setBulletDirection(Utility.DegreeToVector2(currentangle += 360/20));

            }

            timer = 0;
        }
    }
}
