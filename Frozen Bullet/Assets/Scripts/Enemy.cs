using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health;
	public PlayerDirectionController playerDirectionController;
	EnemyPosition enemyPosition;

    // Start is called before the first frame update
    void Start()
    {
		enemyPosition = EnemyPosition.Right;
    }

    // Update is called once per frame
    void Update()
    {

		if (health <= 0)
		{
			Destroy(gameObject);
		}
	}

	private void FixedUpdate()
	{
		movement();
	}

	public void movement() {
		if (playerDirectionController.isFacingEnemy(enemyPosition))
		{
			Vector3 movement = new Vector3(0.5f, 0, 0);

			transform.position += (movement * Time.deltaTime);

		}
	}

	public void takeDamage(int damage) {
        health -= damage;
    }

    
}
