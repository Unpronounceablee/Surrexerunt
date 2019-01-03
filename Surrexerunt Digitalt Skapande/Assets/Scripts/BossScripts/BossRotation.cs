using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRotation : MonoBehaviour {

    public Vector3 distanceToTarget = Vector3.zero;
    public Transform target;
    public float rotationDistance;
    public float rotationPerSecond = 180.0f;
    public bool once = true;

	void Start () {
        if (target != null) {
            distanceToTarget = transform.position - target.position;
        }
	}
	
	void LateUpdate () {
        Rotate();
	}

    void Rotate () {
        if (target != null) {
            transform.position = (target.position + distanceToTarget);
            transform.RotateAround(target.position, Vector3.forward, rotationPerSecond * Time.deltaTime);
        }
        if (once) {
            transform.position *= rotationDistance;
            once = false;
        }

        distanceToTarget = transform.position - target.position;
    }
}
