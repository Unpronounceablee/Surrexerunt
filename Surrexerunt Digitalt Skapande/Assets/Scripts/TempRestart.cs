using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TempRestart : MonoBehaviour {

    public GameObject retry;

	void OnEnable () {
        retry.SetActive(true);

    }
}
