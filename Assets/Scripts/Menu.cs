using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioMixer AM;
    [SerializeField] AudioManager audioManager;
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

    public void PlayPause(string name)
    {
        if (audioManager.Status(name))
        {
            audioManager.Pause(name);
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
}
