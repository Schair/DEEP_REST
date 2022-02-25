using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound 
{
    public string name;
    public AudioClip clip;
    [Range(0.0f, 1.0f)]
    public float volume;
    [Range(-3.0f, 3.0f)]
    public float pitch;
    public bool loop;
    public bool playAtStart;
    public float secondsTillStart;
    public bool fadeIn, fadeOut;
    [HideInInspector]
    public AudioSource source;
}
