using System;
using System.Collections;
using System.Linq;
using Unity.VisualScripting;
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

    //Menu SFX
    [Header("Menu Sounds")]
    [Space]
    [SerializeField] Sound[] _menuSounds;

    //Singleton
    private static AudioManager _instance;
    public static AudioManager Instance => _instance;

    Coroutine _c;

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

        foreach(Sound sound in _menuSounds)
        {
            sound.Source = this.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.outputAudioMixerGroup = sound.OutputAudioMixerGroup;
            sound.Source.loop = sound.Loop;
            sound.Source.volume = sound.Volume;
            sound.Source.pitch = sound.Pitch;
        }
    }

    private void Start()
    {
        _musicSource.clip = _musicClips[0];
        _musicIndex = 0;
        _musicSource.Play();
        _c = StartCoroutine(SongL());
    }

    private void Update()
    {
        
    }

    IEnumerator SongL()
    {
        yield return new WaitForSeconds(_musicSource.clip.length);
        PlayNextMusic();
    }

    /////////////////////
    // Music Functions //
    /////////////////////

    void PlayNextMusic()
    {
        StopCoroutine(_c);
        _musicIndex = (_musicIndex + 1)% _musicClips.Length;
        _musicSource.clip = _musicClips[_musicIndex];
        _musicSource.Play();
        _c = StartCoroutine(SongL());
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

    ////////////////////////
    // Menu SFX Functions //
    ////////////////////////

    public void PlayMenuSFX(string name)
    {
        foreach(Sound sound in _menuSounds)
        {
            if(sound.Name == name)
            {
                sound.Source.Play();
                return;
            }
        }
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

    public void SetMenuSFXVolume(float volume)
    {
        _audioMixer.SetFloat("MenuSFXVolume", volume);
    }
}
