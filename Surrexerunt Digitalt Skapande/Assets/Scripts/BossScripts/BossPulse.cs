using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPulse : MonoBehaviour {

    [Tooltip("How many projectiles?")] public int projectileAmount;
    [Tooltip("How far from character?")] public float circleRadius;
    [Tooltip("Put projectile here")] public GameObject projectilePrefab;
    [Tooltip("Boss Position")] public Transform sceneCenter;

    public List<GameObject> projectiles = new List<GameObject>();

    public float cooldown;
    private float effectiveCooldown;
    private int locationMultiplier;

    void OnEnable() {
        transform.position = sceneCenter.position;
        locationMultiplier = 360 / projectileAmount;
        effectiveCooldown = 2f;
        Vector3 centre = transform.position;
        for (int i = 0; i < projectileAmount; i++) {
            int location = i * locationMultiplier;
            Vector3 pos = CircleMath(centre, circleRadius, location);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, centre - pos);
            projectiles.Add(Instantiate(projectilePrefab, pos, rot));
        }
    }

    void Update() {
        if (effectiveCooldown <= 0) {
            Vector3 centre = transform.position;
            for (int i = 0; i < projectileAmount; i++) {
                int location = i * locationMultiplier;
                Vector3 pos = CircleMath(centre, circleRadius, location);
                Quaternion rot = Quaternion.FromToRotation(Vector3.up, centre - pos);
                projectiles.Add(Instantiate(projectilePrefab, pos, rot));
                effectiveCooldown = cooldown;
            }
        } else {
            effectiveCooldown -= Time.deltaTime;
        }
    }

    Vector3 CircleMath(Vector3 centre, float radius, int location) {
        float ang = location;
        Vector3 pos;
        pos.x = centre.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = centre.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = centre.z;
        return pos;
    }
    private void OnDisable() {
        foreach (GameObject BossProjectile in projectiles) {
            Destroy(BossProjectile);
        }
    }
}
