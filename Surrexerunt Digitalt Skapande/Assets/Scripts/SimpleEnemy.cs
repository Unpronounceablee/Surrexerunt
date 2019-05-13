using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    AudioSource buzzing;
    [SerializeField] ParticleSystem deathBurst;

    [SerializeField] float speed, dirTime;
    float effectiveDirTime;
    bool changeDir = false;
    private GameObject player;
    private bool hasCollided;
    public bool dead;

    private bool runonce;

    private void Start()
    {
        buzzing = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {
        if (!dead)
        {
            MoveEnemy();

        }

        else if(player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Cooldown && !runonce)
        {
            runonce = true;
            player.GetComponent<PlayerMovement>().dashState = PlayerMovement.DashState.CanDash;

        }

    }

    void PlayerInteraction()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Dashing)
        {
            FindObjectOfType<SoundFXManagerScript>().PlaySound("EnemyDeath");
            GetComponent<Animator>().Play("EnemyDead");
            Instantiate(deathBurst, transform.position, transform.rotation);
            if (buzzing.volume > 0f) {
                buzzing.volume = 0;
            }
            dead = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(WaitForParts());

        }
        else
        {
            player.GetComponent<PlayerMovement>().TakeDamage();
        }
    }

    private IEnumerator WaitForParts()
    {

        yield return new WaitForSeconds(0.4f);
        GetComponent<SpriteRenderer>().enabled = false;
        Parts();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && !hasCollided)
        {
            PlayerInteraction();
            StartCoroutine(Wait(0.1f));
        }
    }

    private IEnumerator Wait(float time)
    {
        hasCollided = true;
        yield return new WaitForSeconds(time);
        hasCollided = false;
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (!changeDir)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (changeDir)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (effectiveDirTime <= 0f)
        {
            changeDir = !changeDir;
            effectiveDirTime = dirTime;
        }
        else
        {
            effectiveDirTime -= Time.deltaTime;
        }
    }

    private void Parts()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1), 1f).normalized * 3, ForceMode2D.Impulse);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f, 1), 1f).normalized * 3, ForceMode2D.Impulse);

    }
}
