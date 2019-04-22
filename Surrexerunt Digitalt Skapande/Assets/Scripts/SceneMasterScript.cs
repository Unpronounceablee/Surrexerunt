using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneMasterScript : MonoBehaviour {

    public Animator anim;

    string levelName;

    private void Awake() {
        anim = gameObject.GetComponent<Animator>();
    }

    public void LoadScene(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void OnlyTransition(string transitionToPlay) {
        anim.SetTrigger(transitionToPlay);
    }

    public void Transition(string sceneName) {
        anim.SetTrigger("FadeOut");
        levelName = sceneName;
        StartCoroutine(SceneSwitch());
    }

    public void ReloadTransition (string transitionToPlay) {
        anim.SetTrigger(transitionToPlay);
        StartCoroutine(ReloadStage());
    }

    IEnumerator ReloadStage() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit() {
        Application.Quit();
    }

    IEnumerator SceneSwitch() {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(levelName);
    }

}
