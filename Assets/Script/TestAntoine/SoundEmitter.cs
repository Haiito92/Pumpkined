using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEmitter : MonoBehaviour
{
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _clip;

    public void EmitSound()
    {
        AudioManager.Instance.PlaySFX(_source, _clip);
        //AudioManager.Instance.PlaySFXAtPos(_clip, transform.position); nique ta grosse mere la pouissance
    }
}
