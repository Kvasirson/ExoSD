using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Audio 
{
    public string name;
    
    public AudioClip[] clips;

    public AudioMixerGroup mixerGroup;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;
    public bool playOnAwake;

    [HideInInspector]
    public AudioSource source;

    [HideInInspector]
    public bool hasMultipleClips;
}
