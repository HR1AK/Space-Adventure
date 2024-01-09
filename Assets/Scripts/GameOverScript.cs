using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        MyGameManager.instance.GameOver();
    }
}
