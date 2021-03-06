﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Bullet bullet;
    public float speed;
    public float firerate;
    public int MaximumnHealth;
    public ParticleSystem playerDeathEffect;
    int currentHealth;

    private float timer;
	private bool isDamaged;

    [HideInInspector]
    public static int BulletTime;
    public static bool BulletTimeActivated;
    public static int BulletTimeThreshold = 20;
    // Start is called before the first frame update
    void Start()
    {
		timer = 0;
        currentHealth = MaximumnHealth;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (BulletTime> BulletTimeThreshold) {
            BulletTime = BulletTimeThreshold;
        }

        if (currentHealth <= 0) {
            Level.playerIsDead = true;
            Instantiate(playerDeathEffect, transform.position, transform.rotation);

            Destroy(gameObject);      
        }

		timer += Time.fixedDeltaTime;
        movement();
		if (Input.GetButton("Fire1")) {
			if (timer > firerate) {
				Fire();
				timer = 0;
			}
		}
    }


    void movement() {
        //Mouse Movement

        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);
        transform.position += (speed * movement * Time.fixedDeltaTime);
        float boundX = Mathf.Clamp(transform.position.x, -14, 14);
        float boundY = Mathf.Clamp(transform.position.y, -8, 8);

        transform.position = new Vector3(boundX,boundY,0);

    }

    void Fire() {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    public void takeDamage(int damage) {
		isDamaged = true;
        currentHealth -= damage;
		Invoke("turnNotDamage", 0.1f);
    }

	public void turnNotDamage() {
		isDamaged = false;
	}

    public float getHealthPercentage() {

        float ch = currentHealth;
        float mh = MaximumnHealth;
        return ch / mh;
    }

	public bool isPlayerDamaged() {
		return isDamaged;
	}

}
