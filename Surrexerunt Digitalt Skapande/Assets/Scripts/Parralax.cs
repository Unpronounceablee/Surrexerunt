using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private float parralaxLayer;
    private float offsetX;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offsetX = player.transform.position.x - transform.position.x;


    }

    void FixedUpdate()
    {
        transform.position = new Vector2(offsetX + player.transform.position.x / parralaxLayer, 0);
    }
}
