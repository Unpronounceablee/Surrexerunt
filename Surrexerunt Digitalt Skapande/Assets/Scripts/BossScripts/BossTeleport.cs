using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTeleport : MonoBehaviour {

    public Transform[] tpPos;
    public float speed;
    public float cooldown;

    private float effectiveCooldown;
    private int randomPos;

    void OnEnable () {
        effectiveCooldown = cooldown;
        randomPos = Random.Range(0, tpPos.Length);
	}
	
	void Update () {
        transform.position = Vector2.MoveTowards(transform.position, tpPos[randomPos].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, tpPos[randomPos].position) < 0.1f) {
            if (effectiveCooldown <= 0) {
                randomPos = Random.Range(0, tpPos.Length);
                effectiveCooldown = cooldown;
            } else {
                effectiveCooldown -= Time.deltaTime;
            }
        }
	}
}
