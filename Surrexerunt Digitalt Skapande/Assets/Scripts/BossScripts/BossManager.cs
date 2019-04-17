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

    Animator anim;

    [SerializeField] ParticleSystem damageParticles;

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
        FindObjectOfType<CameraFollow>().bossBattle = true;
        health = startHealth;
        anim = gameObject.GetComponent<Animator>();
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
        bossPulse = gameObject.GetComponent<BossPulse>();
        bossHell = gameObject.GetComponent<BossBulletHell>();
        restart = gameObject.GetComponent<TempRestart>(); //Delete this later
        GAStage();

    }

    private void GAStage() {
        switch (health) {
            case 9:
                bossTeleport.enabled = true;
                break;
            case 8:
                DisableAttacks();
                bossProjectile.enabled = true;
                break;
            case 7:
                DisableAttacks();
                bossVine.enabled = true;
                break;
            case 6:
                DisableAttacks();
                bossPulse.enabled = true;
                break;
            case 5:
                DisableAttacks();
                bossHell.enabled = true;
                bossHell.cooldown = 0.05f;
                bossHell.rotSpeed = 30f;
                break;
            case 4:
                DisableAttacks();
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 3:
                DisableAttacks();
                bossPulse.cooldown = 0.5f;
                bossPulse.enabled = true;
                break;
            case 2:
                DisableAttacks();
                bossHell.enabled = true;
                bossHell.cooldown = 0.02f;
                bossHell.rotSpeed = 50f;
                break;
            case 1:
                DisableAttacks();
                bossHell.cooldown = 0.05f;
                bossHell.rotSpeed = 30f;
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 0:
                StartCoroutine(Die());
                break;
            default:
                Debug.Log("Ooopsie, something went wrong with the Boss Manager");
                break;
        }
    }

    public void TakeDamage() {
        StartCoroutine(RemoveHealth());
    }

    IEnumerator RemoveHealth() {
        DisableAttacks();
        anim.SetBool("PlayingDamageAnim", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("PlayingDamageAnim", false);
        health--;
        GAStage();
    }

    IEnumerator Die() {
        DisableAttacks();
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(2.5f);
        Destroy(gameObject);
    }

    void DisableAttacks() {
        bossTeleport.enabled = false;
        bossProjectile.enabled = false;
        bossVine.enabled = false;
        bossPulse.enabled = false;
        bossHell.enabled = false;
    }

    void PlaySound (string name) {
        FindObjectOfType<SoundFXManagerScript>().PlaySound(name);
    }

    void DamageParticles () {
        if (damageParticles == null) {
            Debug.Log("Damage Particles not found!");
            return;
        }
        Instantiate(damageParticles, transform.position, transform.rotation);
    }
}
