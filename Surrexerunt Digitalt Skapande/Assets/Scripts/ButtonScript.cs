using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour {

    ButtonMasterScript buttonMaster;
    Animator anim;
    AnimatorEvents animEvents;
    [SerializeField] GameObject creditsImage;
    [SerializeField] int buttonID;
    [SerializeField] string buttonType;

    private void Start() {
        buttonMaster = FindObjectOfType<ButtonMasterScript>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update () {
        if (buttonMaster.selectedButton == buttonID) {
            anim.SetBool("selected", true);
            if (Input.GetButtonDown("Submit")) {
                anim.SetBool("pressed", true);
                Clicked();
            }
        } else {
            anim.SetBool("selected", false);
        }
	}

    void Clicked () {
        if (buttonType == "Play") {
            FindObjectOfType<MenuMusicScript>().fadeOut = true;
            FindObjectOfType<SceneMasterScript>().Transition("SimonsBana");
        } else if (buttonType == "Credits") {
            if (creditsImage.activeSelf == false) {
                creditsImage.SetActive(true);
            } else if (creditsImage.activeSelf == true) {
                creditsImage.GetComponent<Animator>().SetTrigger("Disappear");
            }
        } else if (buttonType == "Quit") {
            FindObjectOfType<SceneMasterScript>().Exit();
        } else {
            Debug.Log("Button type not found");
            return;
        }
    }
}
