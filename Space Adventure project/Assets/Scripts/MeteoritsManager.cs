using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeteoritsManager : MonoBehaviour
{

    private int health = 100;
    [SerializeField] private Sprite[] meteoriteSprites = new Sprite[3];
    [SerializeField] SfxManager sfxManager;
    //private float meteoriteScale = 0f;
    //private float rotationSpeed = 0f;

    void Start()
    {
        //rotationSpeed = Random.Range(0.3f, 0.6f);
        GetComponent<SpriteRenderer>().sprite = meteoriteSprites[Random.Range(0,3)]; 
        sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
    }
    
    public void TakeDamage(int damage)
    {
        health -=damage;

        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        sfxManager.PlaySFC(sfxManager.explosion);
        Destroy(gameObject);
    }
}
