using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{

    [SerializeField] float speed, dirTime;
    float effectiveDirTime;
    bool changeDir = false;
    private GameObject player;
    private bool hasCollided;
    private bool dead;



    void Update()
    {
        if (!dead)
        {
            MoveEnemy();

        }

        else if(player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Cooldown)
        {
            player.GetComponent<PlayerMovement>().dashState = PlayerMovement.DashState.CanDash;

        }

    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

    }

    void PlayerInteraction()
    {
        if (player.GetComponent<PlayerMovement>().dashState == PlayerMovement.DashState.Dashing)
        {
            //gameObject.SetActive(false);
            GetComponent<Animator>().Play("EnemyDead");
            dead = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(WaitForParts());

        }
        else
        {
            player.GetComponent<PlayerMovement>().dashState = PlayerMovement.DashState.Knockback;
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
            StartCoroutine(Wait(0.5f));
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
        transform.GetChild(0).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 1).normalized * 3, ForceMode2D.Impulse);
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(1).GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1, 1), 1).normalized * 3, ForceMode2D.Impulse);

    }
}
