using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVine : MonoBehaviour {

    public GameObject[] vinePrefab;
    public Transform vineStart, bossPos;
    public float cooldown;
    private float effectiveCooldown;

	void Start () {
        transform.position = bossPos.position;
	}

    void Update() {
        if (effectiveCooldown <= 0) {
            int randomVine = Random.Range(0, vinePrefab.Length);
            Instantiate(vinePrefab[randomVine], vineStart.position, Quaternion.identity);
            effectiveCooldown = cooldown;
        } else {
            effectiveCooldown -= Time.deltaTime;
        }
    }

}
