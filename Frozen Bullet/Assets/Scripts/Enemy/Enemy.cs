using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyBullet enemyBullet;
    public int health;
    public float shootingTimer;
    public int speed;

    protected Vector2 moveDirection;
    protected bool freeze;
    protected ShootType shootingType;
    protected List<Vector3> MovePoints;
    protected List<float> MovementDelay;
    protected float moveTimer;
    protected bool move;
    protected int movementIndex;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        move = true;
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
        if (MovePoints.Count == 0)
        {

            Vector3 movement = new Vector3(moveDirection.x, moveDirection.y, 0);
            transform.Translate(Vector3.Normalize(movement) * Time.deltaTime * speed);
        }
        else
        {
            if (movementIndex < MovePoints.Count) {
                if (move)
                {
                    transform.position = Vector3.MoveTowards(transform.position, MovePoints[movementIndex], speed * Time.deltaTime);
                    Debug.Log("huihi");

                }

                if (Vector3.Distance(transform.position, MovePoints[movementIndex]) < 0.001f)
                {
                    Debug.Log("The Time");
                    move = false;
                    moveTimer += Time.deltaTime;
                    if (moveTimer >= MovementDelay[movementIndex])
                    {
                        Debug.Log("asds");

                        move = true;
                        moveTimer = 0;
                        movementIndex++;
                    }
                }
         
            }
        }

        shootingType.Fire();
 
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
}
