using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by: Oskar SU16a
public class Movement : MonoBehaviour {

    Rigidbody2D rgbd;
    float xspeed;

    Transform groundCheck;
    public float jumpForce;
    public LayerMask characterMask;
    public bool grounded;

    void Start() {
        rgbd = this.GetComponent<Rigidbody2D>();
        groundCheck = GameObject.Find("groundCheck").GetComponent<Transform>();
    }

    void FixedUpdate() {
        rgbd.velocity = new Vector2(xspeed, rgbd.velocity.y);
        grounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, characterMask);
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow)) {
            xspeed = 5;
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            xspeed = -5;
        } else {
            xspeed = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            jump();
        }
    }

    void jump() {
        if (grounded) {
            rgbd.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }
}