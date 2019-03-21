using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 10;
    public int speed;
    public PlayerDirectionController playerDirection;
    int bulletDir = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (playerDirection.getDirection() == PlayerDirection.Left)
        {
            bulletDir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
  
        Vector3 move = new Vector3(bulletDir, 0, 0);
        transform.position += move * Time.deltaTime* speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage);
        }
    }
}
