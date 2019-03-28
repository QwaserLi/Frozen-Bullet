using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public int speed;


    private void FixedUpdate()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage);
            Destroy(gameObject);
        }

		if (collision.gameObject.tag == "DestroyWall")
		{
			//Do damage and destroy
			Destroy(gameObject);
		}
	}
}
