using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public static AudioManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach( Sound s in Sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    public void Play (string Name)      //use => FindObjectOfType<AudioManager>().Play("AudioName");
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + Name + " not found!");
            return;
        }
        s.Source.Play();
    }


    public void Stop(string Name)      
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == Name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + Name + " not found!");
            return;
        }
        s.Source.Stop();

        //Then use      Stop("Theme");       to stop it
    }
}
