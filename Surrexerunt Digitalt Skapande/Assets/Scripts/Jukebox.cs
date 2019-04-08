using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes sure music isn't interrupted between scenes
/// 
/// Written by: Simon Hansson SU16a
/// </summary>
public class Jukebox : MonoBehaviour {

    void Awake() {
        GameObject[] jukeboxes = GameObject.FindGameObjectsWithTag("Jukebox");
        if (jukeboxes.Length > 1) Destroy(this.gameObject);
        DontDestroyOnLoad(this.gameObject);
    }
}
