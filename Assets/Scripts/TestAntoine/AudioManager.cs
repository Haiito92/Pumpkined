using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //Mixer
    [Header("Mixer")]
    [Space]
    [SerializeField] AudioMixer _audioMixer;
    [SerializeField] AudioMixerGroup _sfxMixerGroup;

    //Music
    [Header("Music")]
    [Space]
    [SerializeField] AudioSource _musicSource;
    [SerializeField] AudioClip[] _musicClips;
    int _musicIndex = 0;

    //SFX

    //Singleton
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _musicSource.clip = _musicClips[0];
        _musicSource.Play();
    }

    private void Update()
    {
        if (!_musicSource.isPlaying)
        {
            PlayNextMusic();
        }

    }

    /////////////////////
    // Music Functions //
    /////////////////////

    void PlayNextMusic()
    {
        _musicIndex = (_musicIndex + 1)% _musicClips.Length;
        _musicSource.clip = _musicClips[_musicIndex];
        _musicSource.Play();
    }

    ///////////////////
    // SFX Functions //
    ///////////////////

    public void PlaySFX(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.outputAudioMixerGroup = _sfxMixerGroup;
        source.Play();
    }

    public void PlaySFXAtPos(AudioClip clip, Vector3 pos)
    {
        GameObject tempGo = new GameObject();
        AudioSource source = tempGo.AddComponent<AudioSource>();
        source.clip = clip;
        source.outputAudioMixerGroup = _sfxMixerGroup;
        source.spatialBlend = 1f;
        source.dopplerLevel = 0f;
        source.Play();
        Destroy(tempGo, clip.length);
    }

    public void PlaySFXAtPos(AudioClip clip, Vector3 pos, float dopplerLevel)
    {
        GameObject tempGo = new GameObject("Temp Sound Emitter");
        AudioSource source = tempGo.AddComponent<AudioSource>();
        source.clip = clip;
        source.outputAudioMixerGroup = _sfxMixerGroup;
        source.spatialBlend = 1f;
        if(dopplerLevel > 0f && dopplerLevel <= 5f) 
        { 
            source.dopplerLevel = dopplerLevel;
        }
        else
        {
            throw new ArgumentException("Doppler level must be between 0 et 5 included");
        }
        source.Play();
        Destroy(tempGo, clip.length);
    }

    /////////////////////////////
    // Settings Menu Functions //
    /////////////////////////////

    public void SetMasterVolume(float volume)
    {
        _audioMixer.SetFloat("MasterVolume", volume);
    }

    public void SetMusicVolume(float volume)
    {
        _audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        _audioMixer.SetFloat("SFXVolume", volume);
    }
}
