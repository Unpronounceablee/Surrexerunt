using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    [SerializeField]float speed, dirTime;
    float effectiveDirTime;
    bool changeDir = false;

	void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (!changeDir) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (changeDir) {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (effectiveDirTime <= 0f) {
            changeDir = !changeDir;
            effectiveDirTime = dirTime;
        } else {
            effectiveDirTime -= Time.deltaTime;
        }
	}
}
