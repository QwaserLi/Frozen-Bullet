using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootType : MonoBehaviour
{
    protected float timer;
    protected float ShootingTimer;
    protected EnemyBullet eb;

    protected void Update()
    {
        timer += Time.deltaTime;
    }

    public void setShootingTimer(float st) {
        ShootingTimer = st;
    }

    public void setBullet(EnemyBullet enemyBullet) {
        eb = enemyBullet;
    }

    public abstract void Fire();

    public static Vector2 RadianToVector2(float radian)
    {
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }

    public static Vector2 DegreeToVector2(float degree)
    {
        return RadianToVector2(degree * Mathf.Deg2Rad);
    }
}
