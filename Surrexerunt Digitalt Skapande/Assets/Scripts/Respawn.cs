using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    
    public GameObject player;
    public int maxLives;
    private int lives;
    public GameObject[] checkpoints;
    public int respawnDepth;


	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y <= respawnDepth)
        {
            RespawnPlayer();
            lives -= 1;
        }
        else if (lives <= 0)
        {
            RestartLevel();
        }
		
	}
    private void Start()
    {
        player = gameObject;
        lives = maxLives;
    }

    private void RespawnPlayer()
    {
        player.transform.position = checkpoints[0].transform.position;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
