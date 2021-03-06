﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ProjectileManager))]
public class Launch : MonoBehaviour {

    [SerializeField] ParticleSystem explosionFX;

    public float speed;

    private Transform player;
    private Vector2 target;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        FindObjectOfType<SoundFXManagerScript>().PlaySound("ThornSwoosh");
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position.x == target.x && transform.position.y == target.y)
        {
            Instantiate(explosionFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
