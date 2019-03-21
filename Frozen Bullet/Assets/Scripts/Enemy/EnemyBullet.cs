using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    int damage = 10;
    public int speed;
    public PlayerDirectionController playerDirectionController;
    EnemyPosition position;
    bool keepGoing;
    Vector2 bulletDirection =  new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x < playerDirectionController.transform.position.x)
        {
            position = EnemyPosition.Left;
        }
        else
        {
            position = EnemyPosition.Right;

        }

    }

    // Update is called once per frame
    void Update()
    {

        float playerXPos = playerDirectionController.getXPosition();

        if (!playerDirectionController.isFacingEnemy(position) || keepGoing)
        {
            float prevXPos = transform.position.x;

            Vector3 move = new Vector3(bulletDirection.x, bulletDirection.y, 0);
            transform.position += move * Time.deltaTime * speed;

            float newXPos = transform.position.x;

            if (prevXPos <= playerXPos && newXPos > playerXPos) {
                keepGoing = true;
            } else if (prevXPos >= playerXPos && newXPos < playerXPos) {
                keepGoing = true;
            }
        }

        if (transform.position.x < playerXPos)
        {
            position = EnemyPosition.Left;
        }
        else
        {
            position = EnemyPosition.Right;

        }
    }

    private void LateUpdate()
    {
        float newPlayerXpos = playerDirectionController.getXPosition();
        float oldPlayerXpos = playerDirectionController.getOldXPosition();


        if (oldPlayerXpos >= transform.position.x && newPlayerXpos < transform.position.x)
        {
            keepGoing = true;
        } else if (oldPlayerXpos <= transform.position.x && newPlayerXpos > transform.position.x) {
            keepGoing = true;
        }
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
}
