using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammunition : MonoBehaviour
{
     public Rigidbody2D rb;
    private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed * (-transform.right);

        Destroy(gameObject, 10);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Weapon weapon = hitInfo.GetComponent<Weapon>();
        if(weapon != null)
        {
            weapon.AddAmmo(5);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
