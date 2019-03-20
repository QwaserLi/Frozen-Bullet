using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject bullet;
    public float speed;
    public int health;
	public PlayerDirectionController playerDirection;
	private float timer;
    // Start is called before the first frame update
    void Start()
    {
		timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
		timer += Time.deltaTime;
        movement();
		if (Input.GetKey(KeyCode.Space)) {
			if (timer > 1) {
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
    }

    void Fire() {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}
