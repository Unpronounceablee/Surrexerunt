using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for moving the player. 
/// If you're unsure of how the script works all variables have descriptions next to them and all methods have summaries above them.
/// 
/// Written By: Simon Hansson SU16a
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    #region Variables
    private Rigidbody2D rb2d;

    [Header("Stats")]
    [SerializeField] private float mSpeed;  //Player speed
    [SerializeField] private float jVelocity;   //Player jump height

    [Header("Ground Check Components")]
    [SerializeField] private LayerMask groundLayer; //What layer(s) is ground?
    [SerializeField] private Transform groundCheck; //From where should the code check if the player is grounded?
    [SerializeField] [Range(0f, 1f)] private float groundCheckCircleRadius; //Radius of the overlap circle (see line 84) that checks whether or not the player is  grounded.
    [SerializeField] public bool isGrounded;   //Is the player grounded?

    private bool willJump;
    #endregion

    #region DashVariables
    public enum DashState { Aiming, Dashing, Cooldown, CanDash, Knockback, CantMove}
    [Header("Dash Variables, always set dash timer")]
    [SerializeField]
    private float dashSpeed; // Dashing speed

    [SerializeField] private float dashSmooting; // Dashing smoothing
    Vector3 refer = Vector3.zero;

    [SerializeField] private float startingDashDuration; // Duration of dash

    private Vector3 dashDir;
    public DashState dashState = DashState.CanDash;
    private bool AllowDash { get { return isGrounded && dashState == DashState.CanDash; } }
    public bool CanMove { get { return dashState == DashState.CanDash || dashState == DashState.Cooldown; } }

    public float dashCooldown = 0.15f;

    [SerializeField] private float keepDashSpeed = 0;

    [SerializeField] public float slowTimeScale;

    [SerializeField] private GameObject aimSprite;
    [SerializeField] private float scissorOffset = 2;

    [SerializeField] private float knockback;
    //[SerializeField] private float cantMoveDur;

    private bool dashButton;

    #endregion

    #region Animation&SpriteVariables

    private Animator plAnimatior;
    private SpriteRenderer spRenderer;

    #endregion


    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        plAnimatior = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();

    }

    void Update()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            willJump = true;
            isGrounded = false;
        }

        AimDash();

        FlipSprite();

        SetAnimatiorVariables();
    }

    void FixedUpdate()
    {
        GroundedChecker();

        Jump();

        if (CanMove)
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
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(x * mSpeed, rb2d.velocity.y);
        rb2d.velocity = movement;
    }

    /// <summary>
    /// Let's the player jump if the player has pressed the jump key && they're grounded.
    /// This one is pretty straight forward. If not, let me know and I'll clarify what it does.
    /// </summary>
    private void Jump()
    {
        if (willJump && isGrounded)
        {
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
    private void GroundedChecker()
    {
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundCheckCircleRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }

    }

    #region DashFunctions

    private IEnumerator Dash()
    {
        StartDash();
        yield return new WaitForSeconds(startingDashDuration);
        StopDash();

    }

    private void StartDash()
    {
        aimSprite.GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<MariofyJump>().enabled = false;
        Time.timeScale = 1;
        rb2d.gravityScale = 0;
        rb2d.velocity = dashDir * dashSpeed;
    }

    private void StopDash()
    {
        rb2d.gravityScale = 4;
        rb2d.velocity *= keepDashSpeed;
        dashState = DashState.Cooldown;
        GetComponent<MariofyJump>().enabled = true;
        StartCoroutine(DashCooldown());
    }


    private IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        dashState = DashState.CanDash;
    }

    private void BeginKnockback()
    {
        aimSprite.GetComponent<SpriteRenderer>().enabled = false;
        Time.timeScale = 1;
        rb2d.AddForce(new Vector2(-knockback * Camera.main.GetComponent<CameraController>().controlOffset, 3), ForceMode2D.Impulse);
        dashState = DashState.CantMove;

        StartCoroutine(Knockback());
    }

    private IEnumerator Knockback()
    {
        while (!isGrounded)
        {
            plAnimatior.Play("Damaged");

            yield return true;
        }

        //yield return new WaitForSeconds(cantMoveDur);
        dashState = DashState.Cooldown;
        StartCoroutine(DashCooldown());


    }

    private void AimDash()
    {
        dashButton = Input.GetButton("ControllerRightBumper");

        switch (dashState)
        {
            case DashState.Aiming:
                SlowCharacter();
                Aim();

                if (!dashButton)
                {
                    dashState = DashState.Dashing;
                    StartCoroutine(Dash());
                    
                }

                break;
            case DashState.Dashing:

                break;

            case DashState.Cooldown:

                break;
            case DashState.CanDash:
                if (dashButton)
                {
                    dashState = DashState.Aiming;
                }
                break;

            case DashState.Knockback:
                BeginKnockback();

                break;
            case DashState.CantMove:

                break;

        }
    }

    private void SlowCharacter()
    {
        Time.timeScale = 1 / slowTimeScale;
        rb2d.velocity *= 0;
    }

    private void Aim()
    {
        dashDir = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        UpdateAimArrow();
    }

    private void UpdateAimArrow()
    {
        aimSprite.GetComponent<SpriteRenderer>().enabled = true;
        aimSprite.transform.position = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized * scissorOffset + transform.position;
        Vector3 vectorToPlayer = transform.position - aimSprite.transform.position;
        float stickAngle = Mathf.Atan2(vectorToPlayer.y, vectorToPlayer.x) * Mathf.Rad2Deg;
        aimSprite.transform.rotation = Quaternion.Euler(new Vector3(0, 0, stickAngle));

    }

    private void FlipSprite()
    {

        if (0 < Input.GetAxis("Horizontal"))
        {
            spRenderer.flipX = false;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(-0.15f, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            spRenderer.flipX = true;
            gameObject.GetComponent<Collider2D>().offset = new Vector2(0.15f, 0);

        }

    }

    private void SetAnimatiorVariables()
    {
        plAnimatior.SetFloat("DirectionX", Input.GetAxisRaw("Horizontal"));
        plAnimatior.SetFloat("DirectionY", Mathf.Asin(Input.GetAxisRaw("Horizontal")) * Mathf.Rad2Deg);
        plAnimatior.SetBool("Grounded", isGrounded);
        plAnimatior.SetFloat("VelocityDown", rb2d.velocity.y);
        plAnimatior.SetBool("DashButton", dashButton);


    }
    #endregion

    public void DoubleJump() {
        rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        rb2d.AddForce(Vector2.up * jVelocity, ForceMode2D.Impulse);
        willJump = false;
    }
}