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

    private TempRestart restart; //delete this later

    void Start () {
        health = startHealth;
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
        bossPulse = gameObject.GetComponent<BossPulse>();
        bossHell = gameObject.GetComponent<BossBulletHell>();
        restart = gameObject.GetComponent<TempRestart>(); //Delete this later
    }
	
	void Update () {
        switch (health) {
            case 9:
                bossTeleport.enabled = true;
                break;
            case 8:
                bossTeleport.enabled = false;
                bossProjectile.enabled = true;
                break;
            case 7:
                bossProjectile.enabled = false;
                bossVine.enabled = true;
                break;
            case 6:
                bossVine.enabled = false;
                bossPulse.enabled = true;
                break;
            case 5:
                bossPulse.enabled = false;
                bossHell.enabled = true;
                bossHell.cooldown = 0.05f;
                bossHell.rotSpeed = 30f;
                break;
            case 4:
                bossHell.enabled = false;
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 3:
                bossTeleport.enabled = false;
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
                restart.enabled = true;
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

    public void TakeDamage() {

        health--;
    }
}
