using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Audio[] sounds;

    void Awake()
    {     
        foreach (Audio s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            
            if (s.mixerGroup != null)
            {
                s.source.outputAudioMixerGroup = s.mixerGroup;
            }

            if (s.clips.Length > 1)
            {
                s.hasMultipleClips = true;
            }
            else
            {
                s.source.clip = s.clips[0];
                s.source.loop = s.loop;
            }          

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.playOnAwake = s.playOnAwake;
        }
    }

    public void Play (string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.Log("null");
            return;
        }  

        if (s.hasMultipleClips)
        {
            int newIndex = UnityEngine.Random.Range(0, s.clips.Length);
            s.source.clip = s.clips[newIndex];
        }
        s.source.Play();

    }
    
    public void Stop (string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;

        s.source.Stop();
    }

    public void Pause (string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return;

        s.source.Pause();
    }

    public bool Status (string name)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
            return false;

        bool status = s.source.isPlaying;
        return status;
    }

    public void PlaySynchro (string name, string trackToSynchro)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);
        Audio track = Array.Find(sounds, sound => sound.name == trackToSynchro);

        if (s != null && s.source.isPlaying)
        {
            track.source.time = s.source.time;
            track.source.Play();
        }
    }

    /*public void Crescendo(string name, float time)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);
        float vol = s.volume;
        for (float t = 0; t <= time; t += Time.deltaTime)
        {
            s.source.volume = t / time * vol;
        }
    }

    public void Decrescendo(string name, float time, float vol)
    {
        Audio s = Array.Find(sounds, sound => sound.name == name);
        float vol = s.volume;
        for (float t = time; t > 0; t -= Time.deltaTime)
        {
            s.source.volume = (t / time)*vol;
        }
    }*/
}
