using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    int damage = 10;
    public int speed;
    Vector2 bulletDirection;
    bool freeze;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // if (!freeze) {
        Vector3 move = new Vector3(bulletDirection.x, bulletDirection.y, 0);
        transform.Translate(Vector3.Normalize(move) * speed * Time.deltaTime);
        // }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Do damage and destroy
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();
            p.takeDamage(damage);
            Destroy(gameObject);
        }

    }

    public void setBulletDirection(Vector2 bulletDir)
    {
        bulletDirection = bulletDir;

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
