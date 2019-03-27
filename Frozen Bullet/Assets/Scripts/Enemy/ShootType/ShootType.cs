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

 
}
