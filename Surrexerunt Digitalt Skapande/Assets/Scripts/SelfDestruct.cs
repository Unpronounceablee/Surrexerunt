using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {


    [SerializeField] float timer;
	
	void Update () {
        if (timer <= 0f) {
            Destroy(gameObject);
        } else {
            timer -= Time.deltaTime;
        }
	}
}
