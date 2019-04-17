using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {


    [SerializeField] float timer;
    [SerializeField] bool destroyParent;
	
	void Update () {
        if (timer <= 0f) {
            if (destroyParent) {
                if (transform.parent.gameObject == null) {
                    Debug.Log("Couldn't find parent");
                    return;
                }
                Destroy(transform.parent.gameObject);
            } else {
                Destroy(gameObject);
            }
        } else {
            timer -= Time.deltaTime;
        }
	}
}
