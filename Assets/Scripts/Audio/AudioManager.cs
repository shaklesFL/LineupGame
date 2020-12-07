using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
  public Sound[] sounds;
  public List<AudioSource> sources = new List<AudioSource>();

    //awake
    void Awake()
  {
    foreach (Sound s in sounds)
    {
      s.source = gameObject.AddComponent<AudioSource>();
      s.source.clip = s.clip;
      s.source.volume = s.volume;
      s.source.pitch = s.pitch;
      s.source.loop = s.loop;

      sources.Add(s.source);
    }

  }

  public void Play(string name)
  {
    Sound s = Array.Find(sounds, sound => sound.name == name);
    s.source.Play();

  }
}
