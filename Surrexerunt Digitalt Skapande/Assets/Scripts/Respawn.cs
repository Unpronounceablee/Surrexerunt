using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    private int currentCheckpoint;
    public GameObject[] checkpoints;
    public int respawnDepth;
    private Image blackImage;
    [SerializeField] private float fadeSpeed;
    private bool respawn = true;
    public GameObject[] enemies;
    private Vector3[] enemyPositions;
    [SerializeField] private GameObject enemy;



    // Update is called once per frame
    void Update()
    {
        FallOff();

    }
    private void Start()
    {
        player = gameObject;
        blackImage = GameObject.Find("FadeToBlack").GetComponent<Image>();
        SaveEnemies();

    }

    private void SaveEnemies()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyPositions = new Vector3[enemies.Length];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemyPositions[i] = enemies[i].transform.position;
        }

    }

    private void RespawnPlayer()
    {
        Camera.main.GetComponent<CameraFollow>().enabled = false;
        player.transform.position = checkpoints[currentCheckpoint].transform.position;
        SnapToPlayer();
        Camera.main.GetComponent<CameraFollow>().enabled = true;


    }

    private void SnapToPlayer()
    {
        Camera.main.transform.position += new Vector3(player.transform.position.x, 0, 0);

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void FallOff()
    {
        if (player.transform.position.y <= respawnDepth)
        {
            if (respawn)
            {
                StartCoroutine(Fade());
                respawn = false;
            }
        }
    }

    public void PlayerDied()
    {
        StartCoroutine(Fade());
        respawn = false;
    }

    private void RespawnEnemies()
    {

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null && enemies[i].GetComponent<SimpleEnemy>().dead)
            {
                GameObject instEnemy = Instantiate(enemy, enemyPositions[i], Quaternion.identity);
                enemies[i] = instEnemy;

            }
            else if (enemies[i] == null)
            {
                GameObject instEnemy = Instantiate(enemy, enemyPositions[i], Quaternion.identity);
                enemies[i] = instEnemy;

            }
        }
    }

    private IEnumerator Fade()
    {

        while (blackImage.color.a < 1)
        {
            blackImage.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed * 1);
            yield return false;
        }

        RespawnEnemies();
        RespawnPlayer();
        respawn = true;
        while (blackImage.color.a > 0)
        {
            blackImage.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed * -1);
            yield return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Checkpoint")
        {
            currentCheckpoint++;
            other.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

}
