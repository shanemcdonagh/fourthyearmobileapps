using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: https://youtu.be/LfU5xotjbPw
public class SoundOptions: MonoBehaviour
{
    // Used to determine the volume set by the pause menu
    // Values retrieved by SoundManager to update values
    public static float musicVolume { get; private set; }
    public static float soundFXVolume { get; private set; }


    // Used in pause menu, controls music
    public void ChangeMusicSlider(float value)
    {
        musicVolume = value;
        SoundManager.SoundManagerInstance.UpdateMixerVolume();
    }

    // Used in pause menu, controls sound effects
    public void ChangeFXSlider(float value)
    {
        soundFXVolume = value;
        SoundManager.SoundManagerInstance.UpdateMixerVolume();
    }
}
