using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource source;

    public Sound[] sounds;

    private static AudioManager instance;

    public static AudioManager Instance { get => instance; }
    public AudioSource Source { get => source; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    public void Play(string name) 
    {
        Sound s = Array.Find(sounds, sound => sound.name.Equals(name));
        source.PlayOneShot(s.clip, s.volume);

    }
}
