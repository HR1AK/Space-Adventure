using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotationAngle = 20f;
    SfxManager sfxManager;
    public AudioClip deathAudio;

    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;

        if(sfxManager == null) 
            sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
    }

    void FixedUpdate()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject)
        {
            sfxManager.PlaySFC(deathAudio);
            MyGameManager.instance.GameOver();
        }
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * speed;
        
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * speed;
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    public void AddAngle()
    {
        transform.RotateAround(transform.position, Vector3.forward, rotationAngle);
    }

    public void SubstractAngle()
    {
        transform.RotateAround(transform.position, Vector3.forward, -rotationAngle);
    }
}
