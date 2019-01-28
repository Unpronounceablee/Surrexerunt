using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

    [Tooltip("How many projectiles?")] public int projectileAmount;
    [Tooltip("How far from character?")] public float circleRadius;
    [Tooltip("Put projectile here")] public GameObject projectilePrefab;
    [Tooltip("Boss Position")]public Transform sceneCenter;

    public List<GameObject> projectiles = new List<GameObject>();

    public float defaultCooldown;
    private float cooldownTime;
    private int locationMultiplier;

    void Start() {
        transform.position = sceneCenter.position;
        locationMultiplier = 360 / projectileAmount;
        cooldownTime = 2f;
        Vector3 centre = transform.position;
        for (int i = 0; i < projectileAmount; i++) {
            int location = i * locationMultiplier;
            Vector3 pos = CircleMath(centre, circleRadius, location);
            Quaternion rot = Quaternion.FromToRotation(Vector3.up, centre - pos);
            projectiles.Add(Instantiate(projectilePrefab, pos, rot));
        }
    }

    void Update() {
        if (cooldownTime <= 0) {
            if (projectiles.Count > 0) {
                int chosenOne = Random.Range(0, projectiles.Count);
                projectiles[chosenOne].GetComponent<ProjectileManager>().activate = true;
                projectiles.Remove(projectiles[chosenOne]);
                cooldownTime = defaultCooldown;
            }
        } else {
            cooldownTime -= Time.deltaTime;
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
}
