using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< HEAD
public class Dash : PlayerMovement
=======

>>>>>>> d4068296107a45544128d63e5b964de9f60410b4
{
    [SerializeField]
    private float dashSpeed;
    private float dashTime;
    [SerializeField]
    private float startDashTime;
    private int direction;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

    }

    // Update is called once per frame
    void Update()
    {

        if (dashTime <= 0)
        {
            direction = 0;
            dashTime = startDashTime;
            rb2d.velocity = Vector2.zero;
        }
        else
        {
            dashTime -= Time.deltaTime;

            if (Input.GetButton("Fire1"))
            {
                Vector3 mousePos;
                mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                rb2d.velocity = mousePos * dashSpeed;
            }

        }
    }
}
