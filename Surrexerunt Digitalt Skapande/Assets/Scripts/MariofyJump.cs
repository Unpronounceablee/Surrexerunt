using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Makes the jump less static. If you hold the jump button
/// the character will do a normal jump but if you quickly press the button
/// the charachter will do a lower jump. Just like in Mario, hence the name.
/// 
/// Written by: Simnon Hansson SU16a
/// </summary>
public class MariofyJump : MonoBehaviour {

    private Rigidbody2D rb2d;

    [SerializeField] private float defaultJump; //Default Jump Height
    [SerializeField] private float lowJump; //Quick-press Jump Height - should be greater than default jump
    [SerializeField] private float fallSpeed;   //The speed at which the player falls - should be slightly greater than lowJump

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (rb2d.velocity.y > 0 && !Input.GetButton("Jump")) {  //If the player releases the jump button while the y-velocity is greater than 0 (during jump)
            rb2d.gravityScale = lowJump;    //Set the gravity scale higher in order to make the chrachter not reach as high
        } else if (rb2d.velocity.y < 0) {   //If the y-velocity is less than 0 (falling)
            rb2d.gravityScale = fallSpeed;  //Set the gravity scale higher to make the character fall faster (juice)
        } else {
            rb2d.gravityScale = defaultJump;    //Else just set the gravity scale to default.
        }
    }
}
