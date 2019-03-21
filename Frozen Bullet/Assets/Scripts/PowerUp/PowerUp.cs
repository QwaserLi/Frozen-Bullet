using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUp : MonoBehaviour
{

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        // When Player enters trigger, activate the powerUp and remove it
        if (other.tag == "Player")
        {
            PlayerController pv = other.gameObject.GetComponent<PlayerController>();
            activatePowerUps(pv);
            Destroy(gameObject);

        }
    }


    public abstract void activatePowerUps(PlayerController player);


}
