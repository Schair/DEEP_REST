using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections;


public class AudioManager : MonoBehaviour
{
    public bool destroyAtChange;
    public Sound[] sounds;
    public static AudioManager instance;
    void Awake()
    {
        if(!destroyAtChange){
            if(instance == null){
                instance = this;
            } else{
                Destroy(gameObject);
                return;
            }
            DontDestroyOnLoad(gameObject);
        }

        foreach (Sound sound in sounds){
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    private void Start() {
        foreach(Sound sound in sounds){
            if(sound.playAtStart){
                StartCoroutine(PlayAtStart(sound));
            }
        }
    }

    public void Play(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        }
        if (s.fadeIn) StartCoroutine(PlayFadeInOne(s));
        else s.source.Play();
    }

    public void Pause(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        }
        if (s.fadeOut) StartCoroutine(PauseFadeOutOne(s));
        else s.source.Pause();
    }

    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        }
        if (s.fadeOut) StartCoroutine(StopFadeOutOne(s));
        else s.source.Stop();
    }

    public void FadeOutOne(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        } else StartCoroutine(StopFadeOutOne(s));
    }

    private void UpdateVolume(string name, float newVolume){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null){ 
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        }
        s.source.volume = newVolume;
    }

    private void UpdatePitch(string name, float newSpeed)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.Log("AUDIO NAME NOT FOUND!");
            return;
        }
        s.source.pitch = newSpeed;
    }

    // Various Coroutines

    private IEnumerator PlayAtStart(Sound sound){
        yield return new WaitForSeconds(sound.secondsTillStart);
        Play(sound.name);
    }

    private IEnumerator PlayFadeInOne(Sound sound){
        float volumeToEqualize = sound.volume;
        sound.volume = 0.0f;
        sound.source.Play();
        while (sound.volume < volumeToEqualize){
            yield return new WaitForSeconds(0.01f);
            sound.volume += 0.01f;
            UpdateVolume(sound.name, sound.volume);
        }
    }

    private IEnumerator StopFadeOutOne(Sound sound){
        Debug.Log("fading out...");
        while(sound.volume > 0.0f){
            yield return new WaitForSeconds(0.01f);
            sound.volume -= 0.01f;
            UpdateVolume(sound.name, sound.volume);
        }
        sound.source.Stop();
    }

    private IEnumerator PauseFadeOutOne(Sound sound){
        Debug.Log("fading out...");
        while(sound.volume > 0.0f){
            yield return new WaitForSeconds(0.01f);
            sound.volume -= 0.01f;
            UpdateVolume(sound.name, sound.volume);
        }
        sound.source.Pause();
    }


}
