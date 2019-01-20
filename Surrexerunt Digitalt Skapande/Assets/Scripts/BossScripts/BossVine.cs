using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVine : MonoBehaviour {

    public GameObject[] vinePrefab;
    public Transform vinePos;
    public Transform bossPos;

    public float defaultCooldown;
    private float cooldownTime;

    void Start () {
        transform.position = bossPos.position;
        cooldownTime = defaultCooldown;
	}

    void Update() {
        if (cooldownTime <= 0) {
            int randomVine = Random.Range(0, vinePrefab.Length);
            Instantiate(vinePrefab[randomVine], vinePos.position, Quaternion.identity);
            cooldownTime = defaultCooldown;
        } else {
            cooldownTime -= Time.deltaTime;
        }
    }

}
