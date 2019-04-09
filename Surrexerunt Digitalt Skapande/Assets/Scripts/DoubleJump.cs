using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

    bool used;
    float cooldown = 5f;
    [SerializeField] private AudioClip coinSound;

    private void Update() {
        if (used == true) {
            ReEnable();
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && used == false) {
            if (Input.GetButtonDown("Jump")) {
                other.GetComponent<PlayerMovement>().isGrounded = true;
                other.GetComponent<PlayerMovement>().DoubleJump();
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<Collider2D>().enabled = false;
                GetComponent<PlaySound>().Play(coinSound);
                used = true;
            }
        }
    }

    private void ReEnable() {
        if (cooldown <= 0f) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
            used = false;
            cooldown = 5f;
        } else {
            cooldown -= Time.deltaTime;
        }
    }
}
