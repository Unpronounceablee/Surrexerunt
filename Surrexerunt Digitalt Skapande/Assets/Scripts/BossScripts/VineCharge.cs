using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VineCharge : MonoBehaviour {

    Transform vineDeath;
    Vector2 target;

    float speed = 5f;

    void Start() {
        vineDeath = GameObject.FindGameObjectWithTag("vineDeath").transform;
        target = new Vector2(vineDeath.position.x, vineDeath.position.y);

    }

    void Update() {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y) {
            Destroy(gameObject);
        }
    }
}
