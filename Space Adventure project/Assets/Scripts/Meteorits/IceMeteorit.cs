using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMeteorit : Meteorit
{
    int debuffTime = 5; //secons
    public override void hitWithPlayer(PlayerMovement player)
    {
        Destroy(this.gameObject);
        if(player.debuffState == player.debuffStates[0])
            player.Freeze(debuffTime);
    }
}
