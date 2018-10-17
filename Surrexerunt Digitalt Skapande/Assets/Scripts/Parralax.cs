using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    //Written by: [Pontus Mattsson][Su16B]
    private GameObject player;
    [SerializeField]
    private float parralaxLayer; // Hur långt bak skall objektet ligga? Högre nummer ger långsammare hastighet.
    private float layerMultipler = 0.5f;
    private float offsetX; //Hur långt ifrån objektet SKA ligger ifrån spelaren i x-led.
    private float xDistanceToPlayer; // Hur långt ifrån objektet ligger från spelaren i x-led.
    [SerializeField] private float resetDistance;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offsetX = player.transform.position.x - transform.position.x;

    }

    void Update()
    {
        transform.position = new Vector2(offsetX + player.transform.position.x / (parralaxLayer * layerMultipler), transform.position.y);

        xDistanceToPlayer = player.transform.position.x - transform.position.x;

        if (xDistanceToPlayer > resetDistance) //Flytta objektet från höger utanför kameran till vänster utanför kameran, eller reverse.
        {
            offsetX += resetDistance * 2;

        }
        else if (xDistanceToPlayer < -resetDistance)
        {
            offsetX -= resetDistance * 2;
        }
    }
}
