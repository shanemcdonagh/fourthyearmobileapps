using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

// Follows same structure as SoundManager I used for my last mobile apps project
public class SoundManager : MonoBehaviour
{
    // Allows for SoundManager to be called from other scripts to play a sound
    public static SoundManager SoundManagerInstance;

    // List of sounds to player
    [SerializeField] private Sound[] sounds;

    // Used to categorize the sound
    [SerializeField] private AudioMixerGroup soundFX;
    [SerializeField] private AudioMixerGroup music;

    void Awake()
    {
        SoundManagerInstance = this;

        // For-each: Sound found in the array
        foreach (Sound sound in sounds)
        {
            // Add an Audio source to the current sound
            sound.audioSource = gameObject.AddComponent<AudioSource>();

            // Initialize properties of the AudioSource
            // Based on settings we have set
            sound.audioSource.volume = sound.volume;
            sound.audioSource.clip = sound.audioClip;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.isLooping;
           
            
            // Determines which mixer group to place the Sound instance in
            if (sound.audioType == Sound.TypesAudio.soundFX)
            {
                sound.audioSource.outputAudioMixerGroup = soundFX;
            }
            else if (sound.audioType == Sound.TypesAudio.music)
            {
                sound.audioSource.outputAudioMixerGroup = music;
            }

            // Plays sound if set to play on Awake
            if (sound.playOnAwake)
            {
                sound.audioSource.Play();
            }
        }
    }

    // Plays a specified sound
    public void PlayClip(string soundName)
    {
        // Checks list of sounds within the sounds array and returns the sound which matches that of passed in string name
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.soundName == soundName);

        // If: The sound exists..
        if (soundToPlay != null)
        {
            // Play the sound
            soundToPlay.audioSource.Play();
        }
    }

    // Stops a specified clip playing
    public void StopClip(string soundName)
    {
        // Checks list of sounds within the sounds array and returns the sound which matches that of passed in string name
        Sound soundToPlay = Array.Find(sounds, dummySound => dummySound.soundName == soundName);

        // If: The sound exists..
        if (soundToPlay != null)
        {
            // Stop the sound
            soundToPlay.audioSource.Stop();
        }
    }

     // Method: Updates volumes based on Pause Menu slider
    public void UpdateMixerVolume()
    {
        // Decibles work through logarithmic scale, therefore we must convert the volume float to decibles
        music.audioMixer.SetFloat("Music Volume",Mathf.Log10(SoundOptions.musicVolume) * 20);
        soundFX.audioMixer.SetFloat("SoundFX Volume",Mathf.Log10(SoundOptions.soundFXVolume) * 20);
    }
    
}
