using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet bullet;
    public float speed;
    public float firerate;
    public int health;

    public PlayerDirectionController playerDirection;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        //playerDirection = GetComponent<PlayerDirectionController>();
		timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
        movement();
		if (Input.GetKey(KeyCode.Space)) {
			if (timer > firerate) {
				Fire();
				timer = 0;
			}
		}

	}


    void movement() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
		playerDirection.ChangeDirection(moveHorizontal);
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += (speed * movement * Time.deltaTime);
        playerDirection.changePosition(transform.position);
    }

    void Fire() {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    public void takeDamage(int damage) {
        health -= damage;
    }
}
