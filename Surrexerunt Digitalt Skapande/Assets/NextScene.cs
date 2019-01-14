using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadSceneAsync("MovementTest");

    }


    [Serializable]
    public class KeepOnSceneChange : MonoBehaviour {
        public void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
