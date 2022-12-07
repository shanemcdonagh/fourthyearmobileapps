using UnityEngine;


[System.Serializable]
public class Sound
{
    // Allows to determine the audio group  
    public enum TypesAudio {soundFX, music}
    public TypesAudio audioType;

    // The sound attributes
    [HideInInspector] public AudioSource audioSource;

    // Sets volume to be default 50%
    [Range(0,1)] public float volume = 0.5f;
    public string soundName;
    public AudioClip audioClip;
    public bool isLooping;
    public bool playOnAwake;  
}
