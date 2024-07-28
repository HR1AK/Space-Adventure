using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeteorit : Meteorit
{
    int debuffTime = 5; //secons

    IceMeteorit()
    {
        health = 100;
        damage = 20;
    }
    public override void hitWithPlayer(PlayerMovement player)
    {
        Destroy(this.gameObject);
        player.TakeDamage(damage);
        if(player.debuffState == player.debuffStates[0])
            player.Freeze(debuffTime);
    }
}
