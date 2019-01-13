using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour {

    public float speed;
    public bool activate = false;
    public Transform boss;

	void Start () {
        gameObject.GetComponent<Launch>().enabled = false;
        boss = GameObject.FindGameObjectWithTag("Boss").transform;
    }
	
	void Update () {
        if (activate == true) {
            gameObject.GetComponent<Launch>().enabled = true;
        } else {
            transform.RotateAround(boss.position, Vector3.forward, speed * Time.deltaTime);
        }
	}
}
