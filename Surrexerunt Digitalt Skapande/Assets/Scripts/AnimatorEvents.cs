using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour {

    void PlayParticleEffect(ParticleSystem effect) {
        Instantiate(effect, transform.position, transform.rotation);
    }

    void TransitionLoadScene(string sceneName) {
        FindObjectOfType<SceneMasterScript>().Transition(sceneName);
    }

    void LoadScen (string sceneName) {
        FindObjectOfType<SceneMasterScript>().LoadScene(sceneName);
    }

    void PlaySound(string soundName) {
        FindObjectOfType<SoundFXManagerScript>().PlaySound(soundName); ;
    }

    void ExitGame() {
        FindObjectOfType<SceneMasterScript>().Exit();
    }

    void DisableSelf() {
        gameObject.SetActive(false);
    }

    void DestroySelf() {
        Destroy(gameObject);
    }
}
