using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiRoofActivate : MonoBehaviour {

    float timer = 2f;

	void Update () {
        if (timer <= 0) {
            gameObject.GetComponent<Collider2D>().enabled = true;
            gameObject.GetComponent<InvisiRoofActivate>().enabled = false;
        } else {
            timer -= Time.deltaTime;
        }
	}
}
