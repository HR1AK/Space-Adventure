using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterBGChange : MonoBehaviour
{
    
    private Image image;
    [SerializeField] private Sprite[] bgSprites = new Sprite[4];

    protected GameObject bg;
    private GameObject Cavebg;
    //bool changeit = true;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if(player)
        {
            image = GameObject.FindGameObjectWithTag("CaveBG").GetComponent<Image>();

            bg = GameObject.FindGameObjectWithTag("BG");
            Cavebg = GameObject.FindGameObjectWithTag("CaveBG");
            image.sprite = bgSprites[Random.Range(0,4)];
            StartCoroutine(ISmoothBGChange());
        }
    }

    IEnumerator ISmoothBGChange()
    {   
        float alpha = 1f;
        Cavebg.GetComponent<Image>().color = new Color(255, 255, 255, 1);
        while (alpha > 0.2f)
        {
            bg.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            alpha -= 0.01f;
            
            yield return new WaitForSeconds(0.01f);
        }

        bg.GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
}
