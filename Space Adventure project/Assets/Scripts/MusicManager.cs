using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    public GameObject BGMusic;
    private AudioSource audioSrc;
    public GameObject[] objs;
    private bool musicOnOff = true;
    
    [SerializeField] private Image imageToggle;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Slider slider;
    
    public virtual void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("Sound");

        if(objs.Length == 0)
        {   
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic";
        }
        else
        {
            BGMusic = GameObject.Find("BGMusic");
        }
        
        //DontDestroyOnLoad(volumeUI);
    }

    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
        if(PlayerPrefs.GetFloat("CustomOptions") == 1)
        {
            if(PlayerPrefs.GetFloat("MusicToggle") == 1)
            {
                imageToggle.sprite = musicOn;
                musicOnOff = true;
                audioSrc.volume = PlayerPrefs.GetFloat("MenuMusic");
                slider.value = PlayerPrefs.GetFloat("MenuMusic");
            }
            else
            {
                imageToggle.sprite = musicOff;
                musicOnOff = false;
                audioSrc.volume = 0;
                slider.value = PlayerPrefs.GetFloat("MenuMusic");
            }
        }
    }

    public void MusicSlider()
    {
        if(musicOnOff)
        {
            audioSrc.volume = slider.value;
        }

        PlayerPrefs.SetFloat("CustomOptions", 1);
        PlayerPrefs.SetFloat("MenuMusic", slider.value);
    }

    public void ToggleTheMusic()
    {
        if(musicOnOff)
        {
            imageToggle.sprite = musicOff;
            audioSrc.volume = 0;
            PlayerPrefs.SetFloat("MusicToggle", 0);
        }
        else
        {
            imageToggle.sprite = musicOn;
            audioSrc.volume = slider.value;
            PlayerPrefs.SetFloat("MusicToggle", 1);
        }
        musicOnOff = !musicOnOff;
        PlayerPrefs.SetFloat("CustomOptions", 1);
    }
}