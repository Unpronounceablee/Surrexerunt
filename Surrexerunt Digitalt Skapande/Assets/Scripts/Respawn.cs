using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn : MonoBehaviour
{

    public GameObject player;
    public int maxLives;
    private int lives;
    public GameObject[] checkpoints;
    public int respawnDepth;
    private Image blackImage;
    [SerializeField] private float fadeSpeed;
    private bool respawn = true;



    // Update is called once per frame
    void Update()
    {
        Death();

    }
    private void Start()
    {
        player = gameObject;
        lives = maxLives;
        blackImage = GameObject.Find("FadeToBlack").GetComponent<Image>();
    }

    private void RespawnPlayer()
    {
        Camera.main.GetComponent<CameraController>().enabled = false;
        player.transform.position = checkpoints[0].transform.position;
        SnapToPlayer();
        Camera.main.GetComponent<CameraController>().enabled = true;


    }

    private void SnapToPlayer()
    {
        Camera.main.transform.position += new Vector3(0, player.transform.position.x, 0);

    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Death()
    {
        if (player.transform.position.y <= respawnDepth)
        {
            if (respawn)
            {
                StartCoroutine(Fade());
                respawn = false;
            }

            lives -= 1;
        }
        else if (lives <= 0)
        {
            RestartLevel();
        }
    }

    private IEnumerator Fade()
    {

        while (blackImage.color.a < 1)
        {
            blackImage.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed * 1);
            yield return false;
        }

        RespawnPlayer();
        respawn = true;
        while (blackImage.color.a > 0)
        {
            blackImage.color += new Color(0, 0, 0, Time.deltaTime * fadeSpeed * -1);
            yield return false;
        }


    }

}
