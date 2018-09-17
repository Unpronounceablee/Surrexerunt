﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for moving the player. 
/// If you're unsure of how the script works all variables have descriptions next to them and all methods have summaries above them.
/// 
/// Written By: Simon Hansson SU16a
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour {
    #region Variables
    protected Rigidbody2D rb2d;

    [Header("Stats")]
    [SerializeField] private float mSpeed;  //Player speed
    [SerializeField] private float jVelocity;   //Player jump height

    [Header("Ground Check Components")]
    [SerializeField] private LayerMask groundLayer; //What layer(s) is ground?
    [SerializeField] private Transform groundCheck; //From where should the code check if the player is grounded?
    [SerializeField] [Range(0f, 1f)] private float groundCheckCircleRadius; //Radius of the overlap circle (see line 84) that checks whether or not the player is  grounded.
    [SerializeField] private bool isGrounded;   //Is the player grounded?

    private bool willJump;
    #endregion

    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump") && isGrounded) {
            willJump = true;
            isGrounded = false;
        }
    }

    void FixedUpdate() {
        GroundedChecker();

        Jump();

        Move();

    }

    /// <summary>
    /// Moves the player.
    /// Gets input from the player then stores that input into a float variable.
    /// That variable is then used in order to create a Vector2 that determines how the player moves.
    /// The float variable we got from the player's input is used to determine the direction (-1 == left, 1 == right),
    /// the mSpeed variable determines the speed at which the player will move,
    /// and rb2d.velocity.y makes sure the player maintains their current y-velocity.
    /// 
    /// Tl;Dr: Moves the player using magic (aka. math).
    /// </summary>
    private void Move() {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(x * mSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
    }

    /// <summary>
    /// Let's the player jump if the player has pressed the jump key && they're grounded.
    /// This one is pretty straight forward. If not, let me know and I'll clarify what it does.
    /// </summary>
    private void Jump() {
        if (willJump && isGrounded) {
            rb2d.AddForce(Vector2.up * jVelocity, ForceMode2D.Impulse);
            willJump = false;
        }
    }

    /// <summary>
    /// Checks if the player is grounded by creating a circular raycast that adds all colliders
    /// that fall within the circle && are on the groundLayer to a list.
    /// If anything gets added to the list that means the player is grounded. It also means
    /// the leagnth of the list is greater than 0 which is why we check for that in the if-statement.
    /// 
    /// Tl;Dr: If the overlap circle touches a collider on the ground-layer the player is grounded and will be able to jump.
    /// </summary>
    private void GroundedChecker() {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckCircleRadius, groundLayer);
        if (colliders.Length > 0) {
            isGrounded = true;
        }

    }
}