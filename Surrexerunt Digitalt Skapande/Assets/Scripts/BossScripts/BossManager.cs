using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour {

    [Tooltip("Set equal to number of attacks")]
    public int startHealth;
    public int health; 

    private BossTeleport bossTeleport;
    private BossProjectile bossProjectile;
    private BossVine bossVine;
	
	void Start () {
        health = startHealth;
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
	}
	
	void Update () {
        if (health == startHealth) {
            bossTeleport.enabled = true;
        } else {
            bossTeleport.enabled = false;
        }
        if (health == startHealth - 1) {
            bossProjectile.enabled = true;
        } else {
            bossProjectile.enabled = false;
        }
        if (health == startHealth - 2) {
            bossVine.enabled = true;
        } else {
            bossVine.enabled = false;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
	}
}
