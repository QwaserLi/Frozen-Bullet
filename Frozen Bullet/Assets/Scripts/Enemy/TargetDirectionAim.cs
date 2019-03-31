using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDirectionAim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Enemy e = GetComponent<Enemy>();
        if (!e.isFrozen())
        {
            if (e.isMoving())
            {
                transform.up = e.getMovementDirection();
            }
            else
            {
                GameObject player = GameObject.FindWithTag("Player");
                if (player != null)
                {
                    Vector3 playerPos = player.transform.position;
                    Vector3 playerDirection = Utility.getDirection(transform.position, playerPos);
                    transform.up = playerDirection;
                }
            }
        }
    }
}
