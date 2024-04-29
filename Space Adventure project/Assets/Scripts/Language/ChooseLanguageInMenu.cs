using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ChooseLanguageInMenu : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI restart;
    [SerializeField] private TextMeshProUGUI musicVolume;

    private TextItems textItems;

    string lang;
    void Awake()
    {
       RefreshWithNewLAnguage();
    }

    void OpenJsonFile(string lang)
    {
        string path = Application.streamingAssetsPath + "/" + lang + ".json";

        if (Application.platform == RuntimePlatform.Android)
        {
        #pragma warning disable 618
            WWW reader = new WWW(path);
            while (!reader.isDone) { }
            textItems = JsonUtility.FromJson<TextItems>(reader.text);
        }
        else
        {
            textItems = JsonUtility.FromJson<TextItems>(File.ReadAllText(path));
        }


        //textItems = JsonUtility.FromJson<TextItems>(File.ReadAllText(path));
    }

    public void RefreshWithNewLAnguage()
    {
        SetLanguage();
        OpenJsonFile(lang);
        SetLanguageOnTextMesh();
    }


    void SetLanguageOnTextMesh()
    {
        restart.text = textItems.restart.ToString();
        musicVolume.text = textItems.musicVolume.ToString();
    }

    void SetLanguage()
    {
        if(PlayerPrefs.GetString("Language") == "ru")
            {
                lang = "ru";
            }
            if(PlayerPrefs.GetString("Language") == "us")
            {
                lang = "us";
            }
    }
}