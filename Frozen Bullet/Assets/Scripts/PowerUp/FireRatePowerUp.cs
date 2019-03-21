using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePowerUp : PowerUp
{
    public override void activatePowerUps(PlayerController player)
    {
        player.firerate = player.firerate / 2;
    }

}
