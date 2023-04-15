using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volumeSetters : MonoBehaviour
{

    [SerializeField]
    private AudioMixer audioMixer;

    //We use playerPrefs to get the volume we have assigned before muting for paused game
    public void SetVolumeGameVolume(float volume)
    {
        audioMixer.SetFloat("gameVolume", volume);
    }

    public void SetVolumeMusicVolume(float volume)
    {
        audioMixer.SetFloat("musicVolume", volume);
    }
}
