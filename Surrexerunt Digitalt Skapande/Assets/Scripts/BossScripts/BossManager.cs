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

    [SerializeField] ParticleSystem damageBurst, damagePetals, finalPetals, finalBurst;

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
        FindObjectOfType<PlayerMovement>().bossBatlle = true;
        health = startHealth;
        anim = gameObject.GetComponent<Animator>();
        bossTeleport = gameObject.GetComponent<BossTeleport>();
        bossProjectile = gameObject.GetComponent<BossProjectile>();
        bossVine = gameObject.GetComponent<BossVine>();
        bossPulse = gameObject.GetComponent<BossPulse>();
        bossHell = gameObject.GetComponent<BossBulletHell>();
        restart = gameObject.GetComponent<TempRestart>(); //Delete this later
        StartCoroutine(BeginFight());

    }

    private void GAStage() {
        switch (health) {
            case 6:
                bossTeleport.enabled = true;
                break;
            case 5:
                DisableAttacks();
                bossProjectile.enabled = true;
                break;
            case 4:
                DisableAttacks();
                bossPulse.enabled = true;
                break;
            case 3:
                DisableAttacks();
                bossHell.enabled = true;
                bossHell.cooldown = 0.1f;
                bossHell.rotSpeed = 69f;
                break;
            case 2:
                DisableAttacks();
                bossTeleport.speed = 80;
                bossTeleport.enabled = true;
                break;
            case 1:
                DisableAttacks();
                bossHell.enabled = true;
                bossHell.cooldown = 0.1f;
                bossHell.rotSpeed = 1337f;
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
        if (health <= 1) {
            Debug.Log("All Projectiles Destroyd");
            DestroyAllProjectiles();
        }
        StartCoroutine(RemoveHealth());
    }

    IEnumerator RemoveHealth() {
        DisableAttacks();
        anim.SetBool("PlayingDamageAnim", true);
        gameObject.GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Collider2D>().enabled = true;
        anim.SetBool("PlayingDamageAnim", false);
        health--;
        GAStage();
    }

    IEnumerator Die() {
        DisableAttacks();
        anim.SetBool("IsDead", true);
        yield return new WaitForSeconds(1.5f);
        FindObjectOfType<SceneMasterScript>().OnlyTransition("FadeOut");
        FindObjectOfType<Jukebox>().killMusic = true;
        yield return new WaitForSeconds(1);
        restart.enabled = true;
        gameObject.SetActive(false);
    }

    IEnumerator BeginFight() {
        FindObjectOfType<SoundFXManagerScript>().PlaySound("GirlLaugh");
        yield return new WaitForSeconds(1);
        GAStage();
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

    void DestroyAllProjectiles () {
        GameObject[] projectiles;
        projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (var Projectile in projectiles) {
            Destroy(Projectile.gameObject);
        }
    }

    #region Particles
    void DamageParticles () {
        if (damageBurst == null) {
            Debug.Log("Damage Burst not found!");
            return;
        }
        Instantiate(damageBurst, transform.position, transform.rotation);
        if (damagePetals == null) {
            Debug.Log("Damage Petals not found!");
            return;
        }
        Instantiate(damagePetals, transform.position, transform.rotation);
    }
    void FinalBurst() {
        if (finalBurst == null) {
            Debug.Log("Final Burst Particles not found!");
            return;
        }
        Instantiate(finalBurst, transform.position, transform.rotation);
    }
    void FinalPetal() {
        if (finalPetals == null) {
            Debug.Log("Final Petals Particles not found!");
            return;
        }
        Instantiate(finalPetals, transform.position, transform.rotation);
    }
    #endregion
}
