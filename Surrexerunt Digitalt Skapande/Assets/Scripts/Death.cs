using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var hit = collision.gameObject;
        var health = hit.GetComponent<HealthPoint>();
        if (health != null)
        {
            health.TakeDamage(3);
        }

        Destroy(gameObject);
    }
}
