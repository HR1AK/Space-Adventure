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
    [SerializeField] private GameObject volumeUI;
    [SerializeField] private Slider slider;
    
    void Awake()
    {
        objs = GameObject.FindGameObjectsWithTag("Sound");

        if(objs.Length == 0)
        {   
            BGMusic = Instantiate(BGMusic);
            BGMusic.name = "BGMusic";
            DontDestroyOnLoad(BGMusic.gameObject);
        }
        else
        {
              BGMusic = GameObject.Find("BGMusic");
        }

        DontDestroyOnLoad(volumeUI);
    }

    void Start()
    {
        audioSrc = BGMusic.GetComponent<AudioSource>();
    }

    public void MusicSlider()
    {
        if(musicOnOff)
        {
            audioSrc.volume = slider.value;
        }
    }

    public void ToggleTheMusic()
    {
        if(audioSrc.volume != 0)
        {
            imageToggle.sprite = musicOff;
            audioSrc.volume = 0;
            musicOnOff = false;
        }
        else
        {
            imageToggle.sprite = musicOn;
            audioSrc.volume = slider.value;
            musicOnOff = true;
        }
        
    }
}
