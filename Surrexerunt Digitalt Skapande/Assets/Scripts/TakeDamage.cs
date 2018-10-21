using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(1);
        }

        Destroy(gameObject);
    }
}
