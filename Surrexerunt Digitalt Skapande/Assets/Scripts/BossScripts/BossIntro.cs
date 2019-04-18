using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : MonoBehaviour {

    Animator anim;
    GameObject boss;

	void Start () {
        boss = GameObject.FindGameObjectWithTag("Boss");
	}

    private void OnTriggerEnter2D(Collider2D other) {
        boss.GetComponent<Collider2D>().enabled = false;
        FindObjectOfType<SoundFXManagerScript>().PlaySound("GirlLaugh");
        boss.GetComponent<FloatDown>().enabled = true;
        Destroy(gameObject);
    }
}
