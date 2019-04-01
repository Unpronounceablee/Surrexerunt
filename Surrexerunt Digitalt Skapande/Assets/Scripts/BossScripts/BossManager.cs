using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region Attributes
[RequireComponent(typeof(BossTeleport))]
[RequireComponent(typeof(BossVine))]
[RequireComponent(typeof(BossProjectile))]
[RequireComponent(typeof(BossPulse))]
[RequireComponent(typeof(BossBulletHell))]
#endregion
public class BossManager : MonoBehaviour {

    [Tooltip("Set equal to number of attacks")]
    public int startHealth;
    public int health; 

    private BossTeleport bossTeleport;
    private BossProjectile bossProjectile;
    private BossVine bossVine;
    private BossPulse bossPulse;
    private BossBulletHell bossHell;

    void Start () {
        health = startHealth;
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
        bossPulse = gameObject.GetComponent<BossPulse>();
        bossHell = gameObject.GetComponent<BossBulletHell>();
    }
	
	void Update () {
        switch (health) {
            case 11:
                bossTeleport.enabled = true;
                break;
            case 10:
                bossTeleport.enabled = false;
                bossProjectile.enabled = true;
                break;
            case 9:
                bossProjectile.enabled = false;
                bossVine.enabled = true;
                break;
            case 8:
                bossVine.enabled = false;
                bossPulse.enabled = true;
                break;
            case 7:
                bossPulse.enabled = false;
                bossHell.enabled = true;
                bossHell.cooldown = 0.05f;
                bossHell.rotSpeed = 30f;
                break;
            case 6:
                bossHell.enabled = false;
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 5:
                bossTeleport.enabled = false;
                bossProjectile.projectileAmount = 15;
                bossProjectile.cooldown = 1f;
                bossProjectile.enabled = true;
                break;
            case 4:
                bossProjectile.enabled = false;
                bossVine.cooldown = 1f;
                bossVine.enabled = true;
                break;
            case 3:
                bossVine.enabled = false;
                bossPulse.cooldown = 0.5f;
                bossPulse.enabled = true;
                break;
            case 2:
                bossPulse.enabled = false;
                bossHell.enabled = true;
                bossHell.cooldown = 0.02f;
                bossHell.rotSpeed = 50f;
                break;
            case 1:
                bossHell.cooldown = 0.05f;
                bossHell.rotSpeed = 30f;
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 0:
                bossHell.enabled = false;
                Destroy(gameObject);
                break;
            default:
                Debug.Log("Ooopsie, something went wrong with the Boss Manager");
                break;
        }
	}

    void StageOne() {
        
    }

    void StageTwo() {

    }

    void StageFinal() {

    }
}
