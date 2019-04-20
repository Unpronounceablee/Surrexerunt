using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEvents : MonoBehaviour {

    void PlayParticleEffect(ParticleSystem effect) {
        Instantiate(effect, transform.position, transform.rotation);
    }

    void LoadScene(string sceneName) {
        FindObjectOfType<SceneMasterScript>().Transition(name);
    }

    void PlaySound(string soundName) {
        FindObjectOfType<SoundFXManagerScript>().PlaySound(name); ;
    }

    void ExitGame() {
        FindObjectOfType<SceneMasterScript>().Exit();
    }
}
