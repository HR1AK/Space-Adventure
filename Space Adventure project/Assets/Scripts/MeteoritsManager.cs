using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MeteoritsManager : MonoBehaviour
{

    [SerializeField] private Sprite[] meteoriteSprites = new Sprite[3];
    //private float meteoriteScale = 0f;
    //private float rotationSpeed = 0f;

    void Start()
    {
        //rotationSpeed = Random.Range(0.3f, 0.6f);
        GetComponent<SpriteRenderer>().sprite = meteoriteSprites[Random.Range(0,3)]; 
    }
    
    void Update()
    {
        //transform.Rotate(0, 0, rotationSpeed * Time.timeScale);
    }
}
