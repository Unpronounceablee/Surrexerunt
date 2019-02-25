using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVine : MonoBehaviour {

    public GameObject[] vinePrefab;
    public Transform vineStart, bossPos;
    public float cooldown;
    private float effectiveCooldown;

	void OnEnable () {
        transform.position = Vector2.MoveTowards(transform.position, bossPos.position, 80f * Time.deltaTime);
    }

    void Update() {
        if (Vector2.Distance(transform.position, bossPos.position) > 0.1f)
            MoveToPosition();

        if (effectiveCooldown <= 0) {
            int randomVine = Random.Range(0, vinePrefab.Length);
            Instantiate(vinePrefab[randomVine], vineStart.position, Quaternion.identity);
            effectiveCooldown = cooldown;
        } else {
            effectiveCooldown -= Time.deltaTime;
        }
    }

    void MoveToPosition() {
        transform.position = Vector2.MoveTowards(transform.position, bossPos.position, 60f * Time.deltaTime);
    }
}
