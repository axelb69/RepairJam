using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Engine.Utils;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource _audioSouce;
    public AudioSource audioSouce{get{return _audioSouce;}}

    [SerializeField]
    private AudioClip[] _clips;
    public AudioClip[] clips {get{return _clips;}}
}
