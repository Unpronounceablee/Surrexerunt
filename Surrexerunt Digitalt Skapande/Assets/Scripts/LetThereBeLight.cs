using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetThereBeLight : MonoBehaviour {

    SpriteRenderer currentSprite;
    [SerializeField] GameObject particlePoint;
    [SerializeField] Sprite lit;
    [SerializeField] ParticleSystem particleEffect;

	void Start () {
        currentSprite = gameObject.GetComponent<SpriteRenderer>();
	}

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            currentSprite.sprite = lit;
            Instantiate(particleEffect, particlePoint.transform.position, particlePoint.transform.rotation);
            FindObjectOfType<SoundFXManagerScript>().PlaySound("Poof");
        }
    }
}
