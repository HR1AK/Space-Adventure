using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SfxManager: MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private Image imageToggle;
    [SerializeField] private Sprite musicOn;
    [SerializeField] private Sprite musicOff;
    [SerializeField] private Slider slider;
    private bool EffectToggle = true;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if(PlayerPrefs.GetFloat("IsCustomEffects") == 1)
        {
            slider.value = PlayerPrefs.GetFloat("EffectValue");

            if(PlayerPrefs.GetFloat("EffectToggle") == 1)
            {
                imageToggle.sprite = musicOn;
                EffectToggle = true;
            }
            else
            {
                imageToggle.sprite = musicOff;
                EffectToggle = false;
            }
        }
    }

    public void PlaySFC(AudioClip clip)
    {
        if(EffectToggle)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void SfxSlider()
    {
        if(EffectToggle)
        {
            audioSource.volume = slider.value;
        }

        PlayerPrefs.SetFloat("IsCustomEffects", 1);
        PlayerPrefs.SetFloat("EffectValue", slider.value);
    }

    public void ToggleEffects()
    {
        if(EffectToggle)
        {
            imageToggle.sprite = musicOff;
            audioSource.volume = 0;
            PlayerPrefs.SetFloat("EffectToggle", 0);
        }
        else
        {
            imageToggle.sprite = musicOn;
            audioSource.volume = slider.value;
            PlayerPrefs.SetFloat("EffectToggle", 1);
        }
        EffectToggle = !EffectToggle;
        PlayerPrefs.SetFloat("IsCustomEffects", 1);
    }
}
