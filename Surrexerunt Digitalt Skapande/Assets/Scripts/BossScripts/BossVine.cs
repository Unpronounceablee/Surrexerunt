using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossVine : MonoBehaviour {

    public GameObject[] vinePrefab;
    public Transform[] vinePos;
    public Transform bossPos;

	void Start () {
        transform.position = bossPos.position;

        for (int i = 0; i < vinePos.Length; i++)
        {
            Instantiate(vinePrefab[i], vinePos[i].position, Quaternion.identity);
        }
	}
	
}
