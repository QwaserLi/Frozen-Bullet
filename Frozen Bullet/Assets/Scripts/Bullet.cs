using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    int damage = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 move = new Vector3(1, 0, 0);
        transform.position += move * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(damage);

        if (collision.gameObject.tag == "Enemy")
        {
            //Do damage and destroy
            Enemy e = collision.gameObject.GetComponent<Enemy>();
            e.takeDamage(damage);
        }
    }
}
