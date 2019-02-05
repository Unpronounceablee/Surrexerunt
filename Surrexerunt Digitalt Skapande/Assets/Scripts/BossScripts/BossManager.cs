using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Attributes
[RequireComponent(typeof(BossTeleport))]
[RequireComponent(typeof(BossVine))]
[RequireComponent(typeof(BossProjectile))]
[RequireComponent(typeof(BossPulse))]
#endregion
public class BossManager : MonoBehaviour {

    [Tooltip("Set equal to number of attacks")]
    public int startHealth;
    public int health; 

    private BossTeleport bossTeleport;
    private BossProjectile bossProjectile;
    private BossVine bossVine;
    private BossPulse bossPulse;


    void Start () {
        health = startHealth;
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
        bossPulse = gameObject.GetComponent<BossPulse>();
    }
	
	void Update () {
        switch (health) {
            case 8:
                bossTeleport.enabled = true;
                break;
            case 7:
                bossTeleport.enabled = false;
                bossProjectile.enabled = true;
                break;
            case 6:
                bossProjectile.enabled = false;
                bossVine.enabled = true;
                break;
            case 5:
                bossVine.enabled = false;
                bossPulse.enabled = true;
                break;
            case 4:
                bossPulse.enabled = false;
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 3:
                bossTeleport.enabled = false;
                bossProjectile.projectileAmount = 15;
                bossProjectile.cooldown = 1f;
                bossProjectile.enabled = true;
                break;
            case 2:
                bossProjectile.enabled = false;
                bossVine.cooldown = 1f;
                bossVine.enabled = true;
                break;
            case 1:
                bossVine.enabled = false;
                bossPulse.cooldown = 0.5f;
                bossPulse.enabled = true;
                break;
            case 0:
                bossPulse.enabled = false;
                Destroy(gameObject);
                break;
            default:
                Debug.Log("Ooopsie, something went wrong with the Boss Manager");
                break;
        }
	}
}
