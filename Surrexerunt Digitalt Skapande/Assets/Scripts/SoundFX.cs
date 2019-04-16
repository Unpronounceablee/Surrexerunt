using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class SoundFX {

    [HideInInspector]public AudioSource audioSource;
    public AudioClip soundFX;

    [Range(0f, 1f)]public float volume;

    public string name;
    public bool loop;

}
