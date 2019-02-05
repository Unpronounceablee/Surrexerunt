﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideShow : MonoBehaviour {
    SpriteRenderer sprites;
    public Sprite[] JonBilder;
    float i = 0;

	// Use this for initialization
	void Start () {
        sprites = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        i += Time.deltaTime * 0.75f;
        if (i >= JonBilder.Length) i = 0;

        sprites.sprite = JonBilder[(int)i];

        if (Time.timeSinceLevelLoad > 4.0f)
        {
            sprites.transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.timeSinceLevelLoad * 2.0f) * Time.timeSinceLevelLoad * 5.0f);
        }

        if (Time.timeSinceLevelLoad > 8.0f)
        {
            sprites.transform.localScale = new Vector3(Mathf.Cos(Time.timeSinceLevelLoad * 3.0f) * 3.0f, Mathf.Sin(Time.timeSinceLevelLoad * 1.5f) * 4.0f, 0);
        }
	}
}
