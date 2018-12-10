using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision)
    {
        print("hit");
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {

            health.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
