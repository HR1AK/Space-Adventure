using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ChooseLanguageInMenu : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI restart;
    [SerializeField] private TextMeshProUGUI musicVolume;
    [SerializeField] private TextMeshProUGUI exit;
    [SerializeField] private TextMeshProUGUI option;
    [SerializeField] private TextMeshProUGUI backToMenu;
    [SerializeField] private TextMeshProUGUI information;

    //Information
    [SerializeField] private TextMeshProUGUI defMet;
    [SerializeField] private TextMeshProUGUI iceMet;
    [SerializeField] private TextMeshProUGUI redMet;
    [SerializeField] private TextMeshProUGUI smallMet;
    [SerializeField] private TextMeshProUGUI starship;
    [SerializeField] private TextMeshProUGUI ammo;
    [SerializeField] private TextMeshProUGUI blackHole;


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
        exit.text = textItems.exit.ToString();
        option.text = textItems.option.ToString();
        backToMenu.text = textItems.backToMenu.ToString();
        information.text = textItems.information.ToString();

        defMet.text = textItems.defMet.ToString();
        iceMet.text = textItems.iceMet.ToString();
        redMet.text = textItems.redMet.ToString();
        smallMet.text = textItems.smallMet.ToString();
        starship.text = textItems.starship.ToString();
        ammo.text = textItems.ammo.ToString();
        blackHole.text = textItems.blackHole.ToString();
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