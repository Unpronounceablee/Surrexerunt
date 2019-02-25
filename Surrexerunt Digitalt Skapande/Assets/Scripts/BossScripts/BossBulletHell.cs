using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletHell : MonoBehaviour {

    [Tooltip("Put projectile here")] public GameObject projectilePrefab;
    [Tooltip("Boss Position")] public Transform sceneCenter;

    public Transform gun;
    public float rotSpeed;
    public float cooldown;
    private float effectiveCooldown;
	
	void Update () {
        if (Vector2.Distance(transform.position, sceneCenter.position) > 0.1f)
            MoveToPosition();
        Shooting();
        gun.Rotate(Vector3.forward * rotSpeed);
    }

    void Shooting() {
        if (effectiveCooldown <= 0) {
            Instantiate(projectilePrefab, gun.position, gun.rotation);
            effectiveCooldown = cooldown;
        } else {
            effectiveCooldown -= Time.deltaTime;
        }
    }
    void MoveToPosition() {
        transform.position = Vector2.MoveTowards(transform.position, sceneCenter.position, 60f * Time.deltaTime);
    }

}
