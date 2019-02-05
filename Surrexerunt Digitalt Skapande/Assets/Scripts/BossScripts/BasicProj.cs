using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicProj : MonoBehaviour {

    float timeAlive = 4f;
    float speed = 4f;
    Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        timeAlive -= Time.deltaTime;
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        if (timeAlive <= 0) {
            Destroy(gameObject);
        }
    }
}
