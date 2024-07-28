using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitBGChange : MonoBehaviour
{
    protected GameObject bg;
    private GameObject Cavebg;
    //bool changeit = true;

    void Awake()
    {
        bg = GameObject.FindGameObjectWithTag("BG");
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if(player)
        {
            bg.SetActive(true);
            Cavebg = GameObject.FindGameObjectWithTag("CaveBG");

            StartCoroutine(ISmoothBGChange());
        }
    }

    IEnumerator ISmoothBGChange()
    {   
        float alpha = 1f;
        float beta = bg.GetComponent<Image>().color.a;
        while (alpha > 0.2f)
        {
            Cavebg.GetComponent<Image>().color = new Color(255, 255, 255, alpha);
            bg.GetComponent<Image>().color = new Color(255, 255, 255, beta);

            alpha -= 0.01f;
            beta += 0.01f;
        
            yield return new WaitForSeconds(0.01f);
        }

        //Cavebg.SetActive(false);
        bg.GetComponent<Image>().color = new Color(255, 255, 255, 1);
    }
}
