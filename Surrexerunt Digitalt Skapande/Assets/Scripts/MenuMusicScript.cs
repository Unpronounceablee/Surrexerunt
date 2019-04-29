using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MenuMusicScript : MonoBehaviour {

    [HideInInspector]public bool fadeOut;

	void Awake () {
        GameObject[] otherMusicPlayers = GameObject.FindGameObjectsWithTag("Jukebox");
        for (int i = 0; i < otherMusicPlayers.Length; i++) {
            Destroy(otherMusicPlayers[i]);
        }
        fadeOut = false;
	}

	void Update () {
        if (fadeOut) {
            gameObject.GetComponent<Animator>().SetTrigger("Out");
        }
	}
}
