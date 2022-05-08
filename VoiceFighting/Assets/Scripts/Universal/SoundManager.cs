using UnityEngine.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private AudioManager _audio;
    public Slider slider;
    public FloatSO scoreSO;

    void Start()
    {
        _audio = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        foreach (Sound s in _audio.sounds)
        {
            s.source.volume = scoreSO.Value;
        }
    }

    public void SetMusicVolume(float volume)
    {
        foreach (Sound s in _audio.sounds)
        {
            s.source.volume = slider.value;
            scoreSO.Value = slider.value;
        }
    }
}

