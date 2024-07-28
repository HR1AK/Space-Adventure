using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Icons : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = new Sprite[2];
    [SerializeField] protected GameObject button;

    public void ChangeSprite()
    {
        if(button.GetComponent<Toggle>().isOn)
        {
            button.GetComponent<Image>().sprite = sprites[0];
            SetLanguageOnPref();
        }
        else
            button.GetComponent<Image>().sprite = sprites[1];
    }

    public virtual void SetLanguageOnPref()
    {
        //
    }
}
