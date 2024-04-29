using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float currentSpeed = 1f;
    float freezeSpeed = 0.2f;
    float normalSpeed;
    [SerializeField] private float rotationAngle = 20f;
    SfxManager sfxManager;
    public AudioClip deathAudio;
    private Rigidbody2D rb;
    private Vector3 startPosition;

    public Dictionary<int, string> debuffStates = new Dictionary<int, string>
    {
        {0, "NONE"},
        {1, "Ice"},
    };

    public string debuffState;

    //Sprites
    [SerializeField] private Sprite iceShipSprite;
    [SerializeField] private Sprite defaultShipSprite;

    //DebuffCanvases
    [SerializeField] TextMeshProUGUI textDebuffTime;

    public int debuffTimeLeft;


    void Start()
    {
        debuffState = debuffStates[0];
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
        normalSpeed = currentSpeed;

        if(sfxManager == null) 
            sfxManager = GameObject.FindGameObjectWithTag("SFXManagerTag").GetComponent<SfxManager>();
    }

    public void GameOver()
    {
        sfxManager.PlaySFC(deathAudio);
        MyGameManager.instance.GameOver();
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * currentSpeed;
        
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * currentSpeed;
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

    public async void Freeze(int debuffTime)
    {
        debuffState = debuffStates[1];
       
        if(this)
            GetComponent<SpriteRenderer>().sprite = iceShipSprite;

        currentSpeed = freezeSpeed;
        
        
        StartCoroutine(IDebuffer(debuffTime)); 
        await Task.Delay(TimeSpan.FromSeconds(5));
        currentSpeed = normalSpeed;
        if(this)
        {
            debuffState = debuffStates[0];
            GetComponent<SpriteRenderer>().sprite = defaultShipSprite; 
        }  
        MyGameManager.instance.HideDebuffCanvas();            
    }

    IEnumerator IDebuffer(int debuffTime)
    {   
        MyGameManager.instance.ShowDebuffCanvas();
        
        debuffTimeLeft = debuffTime;
        textDebuffTime.text = debuffTimeLeft.ToString();
        while(debuffTimeLeft != -1)
        {
            textDebuffTime.text = debuffTimeLeft.ToString();
            debuffTimeLeft--;
            yield return new WaitForSeconds(1);
        }
    }
}
