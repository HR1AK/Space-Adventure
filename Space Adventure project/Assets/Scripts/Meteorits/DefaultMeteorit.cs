using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DefaultMeteorit : Meteorit
{
    [SerializeField] private Sprite[] meteoriteSprites = new Sprite[3];

    public override void GetSprite()
    {
         GetComponent<SpriteRenderer>().sprite = meteoriteSprites[Random.Range(0,3)]; 
    }

    public override void hitWithPlayer(PlayerMovement player)
    {
        player.GameOver();   
    }

}
