using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class usLanguage : Icons
{

    void Awake()
    {
        if(PlayerPrefs.GetString("Language") == "us")
        {
            button.GetComponent<Toggle>().isOn = true;
        }    
        else
        {
            button.GetComponent<Toggle>().isOn = false;
        }
    }
    
    public override void SetLanguageOnPref()
    {
        PlayerPrefs.SetString("Language", "us");
    }
}
