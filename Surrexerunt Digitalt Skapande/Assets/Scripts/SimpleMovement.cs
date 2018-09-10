using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    protected Rigidbody2D rb2d;
    [SerializeField]
    protected float speed;
    

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        ControllObject();
    }

    public void ControllObject()
    {
        rb2d.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));

    }
}
