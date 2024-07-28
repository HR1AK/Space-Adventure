using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveMovement : MonoBehaviour
{
    private float speed = 1f;
    private int damage = 100;
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            player.TakeDamage(damage); 
        }
    }
}
