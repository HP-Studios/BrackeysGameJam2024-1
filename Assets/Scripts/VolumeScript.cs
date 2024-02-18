using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {

            LoadVolume();
        }
        else
        {
            SetSFXVolume();
        }

    }
    public void SetMusicVolume()
    {
        float volume1 = musicSlider.value;
        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume1) * 20);
        PlayerPrefs.SetFloat("MusicVolume", volume1);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume()
    {
        float volume2 = sfxSlider.value;
        audioMixer.SetFloat("SFXVol", Mathf.Log10(volume2) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume2);
        PlayerPrefs.Save();

    }


    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        SetSFXVolume();
        SetMusicVolume();
    }
}
