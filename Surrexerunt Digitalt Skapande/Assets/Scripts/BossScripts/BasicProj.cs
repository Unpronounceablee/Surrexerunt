using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicProj : MonoBehaviour {

    float timeAlive = 3f;
    float speed = 4f;
    float noDmgtime = 0.5f;
    Rigidbody2D rb2d;

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (noDmgtime >= 0f) {
            noDmgtime -= Time.deltaTime;
        }
        timeAlive -= Time.deltaTime;
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
        if (timeAlive <= 0) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player" && noDmgtime <= 0f) {
            FindObjectOfType<PlayerMovement>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
