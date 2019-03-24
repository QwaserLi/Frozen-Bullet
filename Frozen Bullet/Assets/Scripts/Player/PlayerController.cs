using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet bullet;
    public float speed;
    public float firerate;
    public int MaximumnHealth;
    int currentHealth;

    private float timer;


    // Start is called before the first frame update
    void Start()
    {
		timer = 0;
        currentHealth = MaximumnHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Mouse Movement
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        if (currentHealth <= 0) {
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
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += (speed * movement * Time.deltaTime);
    }

    void Fire() {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    public void takeDamage(int damage) {
        currentHealth -= damage;
    }

    public float getHealthPercentage() {

        float ch = currentHealth;
        float mh = MaximumnHealth;
        return ch / mh;
    }

}
