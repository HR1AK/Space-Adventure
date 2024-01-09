using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement2 : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float velocity = 0.5f;
    [SerializeField] private float rotationSpeed = 5f;
    [SerializeField] GameObject player;

    private Rigidbody2D rb;
    private Vector3 startPosition;

    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
        startPosition = player.transform.position;
    }

    void FixedUpdate()
    {
        player.transform.rotation = Quaternion.Euler(0, 0, rb.velocity.y * rotationSpeed);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rb.velocity = Vector2.up * velocity;
    }
}