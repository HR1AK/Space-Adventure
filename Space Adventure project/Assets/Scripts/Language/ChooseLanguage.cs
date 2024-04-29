using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ChooseLanguage : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private TextMeshProUGUI record;
    [SerializeField] private TextMeshProUGUI restart;
    [SerializeField] private TextMeshProUGUI[] exit = new TextMeshProUGUI[2];
    [SerializeField] private TextMeshProUGUI musicVolume;
    [SerializeField] private TextMeshProUGUI effectVolume;
    [SerializeField] private TextMeshProUGUI pause;

    private string lang;

    private TextItems textItems;
    void Awake()
    {
        lang = PlayerPrefs.GetString("Language");
        OpenJsonFile(lang);
        SetLanguageOnTextMesh();
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


    void SetLanguageOnTextMesh()
    {
        currentScore.text = textItems.currentScore.ToString();
        record.text = textItems.record.ToString();
        restart.text = textItems.restart.ToString();

        exit[0].text = textItems.exit.ToString();
        exit[1].text = textItems.exit.ToString();

        musicVolume.text = textItems.musicVolume.ToString();
        effectVolume.text = textItems.effectVolume.ToString();
        pause.text = textItems.pause.ToString();
    }

}
