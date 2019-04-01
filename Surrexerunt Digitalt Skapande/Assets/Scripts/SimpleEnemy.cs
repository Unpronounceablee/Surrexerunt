using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour {

    [SerializeField]float speed, dirTime;
    float effectiveDirTime;
    bool changeDir = false;
    private GameObject player;
    private bool hasCollided;


	void Update () {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (!changeDir) {
            transform.eulerAngles = new Vector3(0, 0, 0);
        } else if (changeDir) {
            transform.eulerAngles = new Vector3(0, -180, 0);
        }

        if (effectiveDirTime <= 0f) {
            changeDir = !changeDir;
            effectiveDirTime = dirTime;
        } else {
            effectiveDirTime -= Time.deltaTime;
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
        }
        else
        {
            player.GetComponent<PlayerMovement>().dashState = PlayerMovement.DashState.Knockback;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && !hasCollided)
        {
            PlayerInteraction();
            StartCoroutine(Wait());
        }
    }

    private IEnumerator Wait()
    {
        hasCollided = true;
        yield return new WaitForSeconds(0.5f);
        hasCollided = false;
    }
}
