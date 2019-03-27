using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralShootType : ShootType
{
    float currentangle = 0;
    float currentangle2 = 180;

    public override void Fire()
    {
        if (timer > ShootingTimer)
        {
            EnemyBullet a = Instantiate(eb, transform.position, transform.rotation);
            a.setBulletDirection(Utility.DegreeToVector2(currentangle+=22.5f));

            timer = 0;
        }
    }


}
