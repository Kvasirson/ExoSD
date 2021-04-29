using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioMixer AM;
    [SerializeField] AudioManager audioManager;
    string retrievedString;
    #endregion

    public void SetMasterVolume(float v)
    {
        AM.SetFloat("MasterVolume", v);
    }

    public void SetMusicVolume(float v)
    {
        AM.SetFloat("MusicVolume", v);
    }

    public void SetSFXVolume(float v)
    {
        AM.SetFloat("SFXVolume", v);
    }

    public void Play(string name)
    {
        audioManager.Play(name);
    }

    public void PlayPause(string name)
    {
        if (audioManager.Status(name))
        {
            audioManager.Pause(name);
            if (audioManager.Status("Tension"))
            {
                audioManager.Stop("Tension");
            }
            audioManager.Stop(retrievedString);
        }
        else
        {
            audioManager.Play(name);
        }
    }

    public void PlayStop(string name)
    {
        if (audioManager.Status(name))
        {
            audioManager.Stop(name);
        }
        else
        {
            audioManager.Play(name);
        }
    }

    public void GetString (string name)
    {
        retrievedString = name;
    }

    public void PlaySynchro(string name)
    {
        if (audioManager.Status(name))
        {
            audioManager.Stop(name);
        }
        else
        {
            audioManager.PlaySynchro(retrievedString, name);
        }
    }

    public void PlayandStop(string name)
    {
        if (audioManager.Status(retrievedString))
        {
            audioManager.Stop(retrievedString);
            if (audioManager.Status("Tension"))
            {
                audioManager.Stop("Tension");
            }
        }
        audioManager.Play(name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
