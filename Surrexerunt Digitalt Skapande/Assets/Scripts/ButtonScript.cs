using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {

    ButtonMasterScript buttonMaster;
    Animator anim;
    AnimatorEvents animEvents;
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
            FindObjectOfType<SceneMasterScript>().Transition("SimonsBana");
        } else if (buttonType == "Credits") {
            //credits
        } else if (buttonType == "Quit") {
            FindObjectOfType<SceneMasterScript>().Exit();
        } else {
            Debug.Log("Button type not found");
            return;
        }
    }
}
