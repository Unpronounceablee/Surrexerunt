﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionTrigger : MonoBehaviour {

    [SerializeField] string sceneName;

    private void OnTriggerEnter2D(Collider2D other) {
        FindObjectOfType<SceneMasterScript>().Transition(sceneName);
        FindObjectOfType<Jukebox>().killMusic = true;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }

}
