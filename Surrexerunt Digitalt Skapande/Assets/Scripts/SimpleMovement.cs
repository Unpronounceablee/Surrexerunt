using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    public static float speed = 10;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ControllObject();
    }

    public virtual void ControllObject()
    {
        rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

    }

}
