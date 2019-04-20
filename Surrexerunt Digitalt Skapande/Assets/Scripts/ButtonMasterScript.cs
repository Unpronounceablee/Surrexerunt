using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMasterScript : MonoBehaviour {

    [SerializeField][Tooltip("Number of buttons minus 1")] int numOfButtons;
    [HideInInspector]public int selectedButton;
    bool keyDown;
	
	void Update (){
        if (Input.GetButtonDown("Vertical")) {
            if (Input.GetAxis("Vertical") < 0) {
                if (selectedButton < numOfButtons) {
                    selectedButton++;
                } else {
                    selectedButton = 0;
                }
            } else if (Input.GetAxis("Vertical") > 0) {
                if (selectedButton > 0) {
                    selectedButton--;
                } else {
                    selectedButton = numOfButtons;
                }
            }
        }
	}
}
