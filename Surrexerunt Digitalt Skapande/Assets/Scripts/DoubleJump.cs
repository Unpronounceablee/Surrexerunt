using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player") {
            if (Input.GetButtonDown("Jump")) {
                other.GetComponent<PlayerMovement>().isGrounded = true;
                other.GetComponent<PlayerMovement>().DoubleJump();
                Destroy(gameObject);
            }
        }
    }
}
