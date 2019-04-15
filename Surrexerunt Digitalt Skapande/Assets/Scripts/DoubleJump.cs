using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour {

    [SerializeField]GameObject explosionFX;

    bool used;
    float cooldown = 2f;

    private void Update() {
        if (used == true) {
            ReEnable();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && used == false) {
            Instantiate(explosionFX, transform.position, transform.rotation);
            other.GetComponent<PlayerMovement>().isGrounded = true;
            other.GetComponent<PlayerMovement>().DoubleJump();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            used = true;

        }
    }

    private void ReEnable() {
        if (cooldown <= 0f) {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = true;
            used = false;
            cooldown = 2f;
        } else {
            cooldown -= Time.deltaTime;
        }
    }
}
