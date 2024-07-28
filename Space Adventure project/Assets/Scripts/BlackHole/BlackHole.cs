using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{  

    void Awake()
    {
        Destroy(gameObject, 20f);
    }
    private float speed = 1f;
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.transform.position = Vector3.MoveTowards(other.transform.position, new Vector3(other.transform.position.x, transform.position.y, 0), 0.01f);
      
    }
}
