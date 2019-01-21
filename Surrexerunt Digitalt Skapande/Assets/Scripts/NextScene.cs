using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    public string scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadSceneAsync(scene);

    }


    [Serializable]
    public class KeepOnSceneChange : MonoBehaviour {
        public void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
