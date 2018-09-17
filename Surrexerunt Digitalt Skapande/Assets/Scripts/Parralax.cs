using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float parralaxLayer;
    private float offsetX;
    private float xDistanceToPlayer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offsetX = player.transform.position.x - transform.position.x;

    }

    void Update()
    {
        transform.position = new Vector2(offsetX + player.transform.position.x / parralaxLayer, transform.position.y);

        xDistanceToPlayer = player.transform.position.x - transform.position.x;

        if (xDistanceToPlayer > 10)
        {
            offsetX += 20;

        }
        else if (xDistanceToPlayer < -10)
        {
            offsetX -= 20;
        }
    }
}
