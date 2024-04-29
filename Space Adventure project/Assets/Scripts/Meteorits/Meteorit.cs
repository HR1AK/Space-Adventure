using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Meteorit : MonoBehaviour
{
    protected int health = 100;
    [SerializeField] protected Sprite meteoriteSprite;
    protected SfxManager sfxManager;
    protected float rotationSpeed = 0f;
    public AudioClip explosionAudio;
    protected float meteoriteScale;

    [SerializeField] protected float minScale;
    [SerializeField] protected float maxScale;

    [SerializeField] protected float minRotate;
    [SerializeField] protected float maxRotate;

    private float speed = 1f;

    [SerializeField] protected GameObject explosionAnimation;


    public void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
        GetSprite();
        rotationSpeed = Random.Range(minRotate, maxRotate);

        //scale
        meteoriteScale = Random.Range(minScale, maxScale); 
        transform.localScale = new Vector3(meteoriteScale, meteoriteScale, meteoriteScale);
    }

    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        transform.rotation *= Quaternion.Euler(0, 0, rotationSpeed * Time.timeScale * Time.deltaTime);
    }
    
    public void TakeDamage(int damage)
    {
        health -=damage;

        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        if(sfxManager == null) 
            sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
        sfxManager.PlaySFC(explosionAudio);

        Instantiate(explosionAnimation, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

     void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if(bullet != null)
        {
            TakeDamage(bullet.damage);
        }
       
    }


    

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

        if(player != null)
        {
            hitWithPlayer(player);
        }

        Die();
    }

    

    public virtual void hitWithPlayer(PlayerMovement player)
    {
        player.GameOver();   
    }

    public virtual void GetSprite()
    {
        GetComponent<SpriteRenderer>().sprite = meteoriteSprite;
    }
}