using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMasterScript : MonoBehaviour {

    [SerializeField][Tooltip("Number of buttons minus 1")] int numOfButtons;
    [HideInInspector]public int selectedButton;
    bool loopPreventer;
	
	void Update (){
        if (Input.GetAxis("Vertical") != 0) {
            if (!loopPreventer) {
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
                loopPreventer = true;
            }
        } else {
            loopPreventer = false;
        }
	}
}
