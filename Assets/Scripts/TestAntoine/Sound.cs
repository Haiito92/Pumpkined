using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    [SerializeField] string _name = "New Sound";
    [SerializeField] AudioClip _clip;

    AudioSource _source;
    [SerializeField] AudioMixerGroup _outputAudioMixerGroup;
    [SerializeField] bool _loop;
    [SerializeField, Range(0.0f, 1.0f)] float _volume = 1.0f;
    [SerializeField, Range(-3.0f, 3.0f)] float _pitch = 1.0f;


    #region Properties
    public string Name { get => _name; set => _name = value; }
    public AudioClip Clip { get => _clip; set => _clip = value; }
    public AudioSource Source { get => _source; set => _source = value; }
    public AudioMixerGroup OutputAudioMixerGroup { get => _outputAudioMixerGroup; set => _outputAudioMixerGroup = value; }
    public bool Loop { get => _loop; set => _loop = value; }
    public float Volume { get => _volume; set => _volume = value; }
    public float Pitch { get => _pitch; set => _pitch = value; }
    #endregion
}
