using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBullet enemyBullet;
    public int health;
    public float shootingTimer;

    protected Vector2 moveDirection;
    protected bool freeze;
    protected ShootType shootingType;


    // Start is called before the first frame update
    protected virtual void Start()
    {
        shootingType = GetComponent<ShootType>();
        shootingType.setShootingTimer(shootingTimer);
        shootingType.setBullet(enemyBullet);
        moveDirection = new Vector2(0, Random.Range(-3f, 3f));
    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void FixedUpdate()
    {
        if (!freeze)
        {
            movement();
        }
    }

    public virtual void movement()
    {

        Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0);
        transform.position += (movement * Time.deltaTime);

        if (transform.position.y >= 4 || transform.position.y <= -4)
        {
            moveDirection = -moveDirection;
        }

        shootingType.Fire();
 
    }

    public virtual void takeDamage(int damage)
    {
        health -= damage;
    }

    protected virtual void Fire()
    {
        EnemyBullet e = Instantiate(enemyBullet, transform.position, transform.rotation);
        e.setBulletDirection(new Vector2(-1, 0));

    }

    public void Freeze()
    {
        freeze = true;
    }

    public void UnFreeze()
    {
        freeze = false;
    }
}
