using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocity = 0.5f;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] SfxManager sfxManager;

    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject)
        {
            sfxManager.PlaySFC(sfxManager.death); //Звуковой эффект
            MyGameManager.instance.GameOver();
        }
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * velocity;
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * velocity;
    }
}
