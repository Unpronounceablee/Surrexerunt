using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Dash : MonoBehaviour
{
    [SerializeField] private float dashSpeed;

    [SerializeField] private float startDashTime; // Dash duration
    private float dashTime; // Copies startDashTime and gets reset to it when duration ends
    private bool startTimer; // Start dash and begin timer for when it ends

    private Vector3 dashDir; // Dash direction

    private PlayerMovement plMove;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UseDash();
    }

    private void UseDash()
    {
        if (Input.GetButton("Fire1") && !startTimer)
        {
            Vector3 sp;
            sp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dashDir = (sp - transform.position).normalized;
            startTimer = true;

        }
        else if (startTimer)
        {
            print(dashTime);
            dashTime -= Time.deltaTime;
            rb2d.AddForce(dashDir * dashSpeed, ForceMode2D.Impulse);
        }

        if (dashTime <= 0)
        {
            print("asd");

            startTimer = false;
            dashTime = startDashTime;
            rb2d.velocity = new Vector2(0,0);
        }
    }
}
