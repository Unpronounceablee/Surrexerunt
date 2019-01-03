using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour {

    public Transform[] tpPos;
    public float speed;
    public float defaultCooldown;

    private float cooldownTime;
    private int randomPos;

	void Start () {
        cooldownTime = defaultCooldown;
        randomPos = Random.Range(0, tpPos.Length);
	}
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, tpPos[randomPos].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, tpPos[randomPos].position) < 0.1f) {
            if (cooldownTime <= 0) {
                randomPos = Random.Range(0, tpPos.Length);
                cooldownTime = defaultCooldown;
            } else {
                cooldownTime -= Time.deltaTime;
            }
        }
	}
}
