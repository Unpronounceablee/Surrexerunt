using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class SoundFXManagerScript : MonoBehaviour {

    public SoundFX[] soundEffects;

	void Awake () {
        DontDestroy();
        MakeList();
    }

    private void DontDestroy() {
        GameObject[] soundManagers = GameObject.FindGameObjectsWithTag("SoundManager");
        if (soundManagers.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }

    private void MakeList() {
        foreach (SoundFX soundEffect in soundEffects) {
            soundEffect.audioSource = gameObject.AddComponent<AudioSource>();
            soundEffect.audioSource.clip = soundEffect.soundFX;
            soundEffect.audioSource.volume = soundEffect.volume;
            soundEffect.audioSource.loop = soundEffect.loop;
            soundEffect.audioSource.pitch = soundEffect.pitch;
        }
    }

    public void PlaySound (string name) {
        SoundFX soundEffectToPlay = Array.Find(soundEffects, soundEffect => soundEffect.name == name); //Letar igenom arryn "soundEffects" efter en soundEffect där namnvariabeln matchar stringen vi tagit emot.
        if (soundEffectToPlay == null) {
            Debug.Log(name + "couldn't be found. You probably spelled it wrong.");
            return;
        }
        soundEffectToPlay.audioSource.Play();
	}
    public void StopSound (string name) {
        SoundFX soundEffectToPlay = Array.Find(soundEffects, soundEffect => soundEffect.name == name); //Letar igenom arryn "soundEffects" efter en soundEffect där namnvariabeln matchar stringen vi tagit emot.
        if (soundEffectToPlay == null) {
            Debug.Log(name + "couldn't be found. You probably spelled it wrong.");
            return;
        }
        soundEffectToPlay.audioSource.Stop();
    }
}
