using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundController : MonoBehaviour
{

    public AudioMixer audioMixer;

    public AudioSource audio;

    public void PlayButtonClick()
    {
        audio.Play();
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume",volume);
    }
}
