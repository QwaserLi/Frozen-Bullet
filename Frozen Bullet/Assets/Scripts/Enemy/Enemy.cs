using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBullet enemyBullet;
    public int health;
	public PlayerDirectionController playerDirectionController;
	protected EnemyPosition enemyPosition;
    protected EnemyPosition initialPosition;
    protected Vector2 moveDirection;
    protected float timer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (transform.position.x < playerDirectionController.transform.position.x)
        {
            enemyPosition = EnemyPosition.Left;
        }
        else
        {
            enemyPosition = EnemyPosition.Right;

        }
        initialPosition = enemyPosition;
        moveDirection = new Vector2(0, Random.Range(-3f, 3f));
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (transform.position.x < playerDirectionController.transform.position.x)
        {
            enemyPosition = EnemyPosition.Left;
        }
        else
        {
            enemyPosition = EnemyPosition.Right;

        }

        if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

    protected virtual void FixedUpdate()
	{
		movement();
	}

    public virtual void movement() {
		if (!playerDirectionController.isFacingEnemy(enemyPosition))
		{
            Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0);
			transform.position += (movement * Time.deltaTime);

            if (transform.position.y >= 4 || transform.position.y <= -4) {
                moveDirection = -moveDirection;
            }

            //Shooting Timer
            timer += Time.deltaTime;

            if (timer > 0.3f)
            {
                Fire();
                timer = 0;
            }

        }
	}

	public virtual void takeDamage(int damage) {
        health -= damage;
    }

    protected virtual void Fire()
    {
        EnemyBullet e = Instantiate(enemyBullet, transform.position, transform.rotation);
        if (initialPosition == EnemyPosition.Left) {
            e.setBulletDirection(new Vector2(1, 0));
        }
        else {
            e.setBulletDirection(new Vector2(-1, 0));

        }
    }
}
