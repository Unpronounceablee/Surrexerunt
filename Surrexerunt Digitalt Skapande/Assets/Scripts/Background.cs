using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : SimpleMovement
{
    [SerializeField]
    private float divideSpeedByThis;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = speed / divideSpeedByThis;
    }

    void FixedUpdate()
    {
        ControllObject();
    }



}
