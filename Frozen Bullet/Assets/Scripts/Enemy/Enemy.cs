using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBullet enemyBullet;
    public int health;
    public float shootingTimer;
    public int speed;
    public ParticleSystem deathEffect;
    protected Vector2 moveDirection;
    protected bool freeze;
    protected ShootType shootingType;
    protected List<Vector3> MovePoints;
    protected List<float> MovementDelay;
	protected float moveTimer;
    protected bool move;
	protected bool shoot;
	protected bool moveShoot;

	protected int movementIndex;
    // Start is called before the first frame update
    protected virtual void Start()
    {
		//moveShoot = false;
		//Move set to false for Testing 
		//move = false;
		move = true;
		shoot = true;
        movementIndex = 0;
        shootingType = GetComponent<ShootType>();
        shootingType.setShootingTimer(shootingTimer);
        shootingType.setBullet(enemyBullet);

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        if (health <= 0)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
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
        if (MovePoints == null || MovePoints.Count == 0)
        {

            Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0);
            transform.Translate(Vector3.Normalize(movement) * Time.fixedDeltaTime * speed);
        }
        else
        {
            if (movementIndex < MovePoints.Count ) {
                if (move)
                {
                    transform.position = Vector3.MoveTowards(transform.position, MovePoints[movementIndex], speed * Time.fixedDeltaTime);

                }

                if (Vector3.Distance(transform.position, MovePoints[movementIndex]) < 0.001f)
                {
					if (MovementDelay == null || MovementDelay.Count == 0)
					{
						movementIndex++;
					}
					else
					{
						move = false;
						moveTimer += Time.fixedDeltaTime;
						if (movementIndex < MovementDelay.Count)
						{
							if (moveTimer >= MovementDelay[movementIndex])
							{
								move = true;
								moveTimer = 0;
								movementIndex++;

							}
						}
					}
                }
         
            }
        }

		if (moveShoot)
		{
			if (shoot && move)
			{
				shootingType.Fire();
			}
		}
		else {
			if (shoot && !move)
			{
				shootingType.Fire();
			}

		}
	
    }

    public Vector3 getMovementDirection() {
            return Utility.getDirection(transform.position, MovePoints[movementIndex]);

    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "DestroyWall") {
			health = -10000;

		}
	}

	public virtual void takeDamage(int damage)
    {
        health -= damage;
    }

    public void Freeze()
    {
        freeze = true;
    }

    public void UnFreeze()
    {
        freeze = false;
    }

	public void SetMoveDirection(Vector2 movement) {
		moveDirection = movement;

	}

    public void SetSpeed(int speed)
    {
        this.speed = speed;

    }

    public void SetMovePoint(List<Vector3> movePoints) {
        MovePoints = movePoints;

    }

    public void SetMovementDelay(List<float> moveDelay)
    {
        MovementDelay = moveDelay;
    }

	public void toggleShootingTime(float time) {
		Invoke("toggleShooting", time);
	}

	public void toggleShooting() {
		shoot = !shoot;
	}

	public void shootWhileMoving(bool shootwhileMoving)
	{
		moveShoot = shootwhileMoving;
	}

    public bool isMoving(){
        return move;
    }

    public bool isFrozen()
    {
        return freeze;
    }
}
