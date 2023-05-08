using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    private void Awake()
    {
        instance= this;
    }

    private void Start()
    {
        PlayMusic("Ambient");
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if(s == null) 
        {
            Debug.Log("Sound Not Found!");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name) 
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.Log("Sound Not Found!");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    //Audio toggle and addjustment stuff//

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }
    public void ToggleSFX()
    {
        sfxSource.mute= !sfxSource.mute;
    }
    public void MusicVolume(float volume)
    {
        musicSource.volume = volume; 
    }
    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }



}