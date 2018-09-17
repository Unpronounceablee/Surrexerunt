using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : PlayerMovement {
    private float dashSpeed;
    private float dashTime;
    private float startDashTime;
    private int direction;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;

	}
	
	// Update is called once per frame
	void Update () {
        if (direction==0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = 1;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = 2;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = 3;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = 4;
            }
            else
            {
                if (dashTime<= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb2d.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime;

                    if (direction==1)
                    {
                        rb2d.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction ==2)
                    {
                        rb2d.velocity = Vector2.right * dashSpeed;
                    }
                    else if (direction == 3)
                    {
                        rb2d.velocity = Vector2.up * dashSpeed;
                    }
                    else if (direction == 4)
                    {
                        rb2d.velocity = Vector2.down * dashSpeed;
                    }

                }
            }
        }
	}
}
