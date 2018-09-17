using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    //Written by: [Pontus Mattsson][Su16B]
    private GameObject player;
    [SerializeField]
    private float parralaxLayer; // Hur långt bak skall objektet ligga? Högre nummer ger långsammare hastighet.
    private float offsetX; //Hur långt ifrån objektet SKA ligger ifrån spelaren i x-led.
    private float xDistanceToPlayer; // Hur långt ifrån objektet ligger från spelaren i x-led.

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offsetX = player.transform.position.x - transform.position.x;

    }

    void Update()
    {
        transform.position = new Vector2(offsetX + player.transform.position.x / parralaxLayer, transform.position.y);

        xDistanceToPlayer = player.transform.position.x - transform.position.x;

        if (xDistanceToPlayer > 10) //Flytta objektet från höger utanför kameran till vänster utanför kameran, eller reverse.
        {
            offsetX += 20; 

        }
        else if (xDistanceToPlayer < -10)
        {
            offsetX -= 20;
        }
    }
}
