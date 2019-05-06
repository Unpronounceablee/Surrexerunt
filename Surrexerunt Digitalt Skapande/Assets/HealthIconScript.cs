using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIconScript : MonoBehaviour {

    Animator anim;
    SpriteRenderer thisSpriteRenderer;
    PlayerMovement playerMovement;

    [SerializeField] int index;

    private void Awake() {
        anim = gameObject.GetComponent<Animator>();
        thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement.health >= index) 
            thisSpriteRenderer.enabled = true;
    }

    void OnEnable () {
		
	}

    IEnumerator Display() {
        yield return new WaitForSeconds(0.5f);
        anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(0.5f);
        if (playerMovement.health < index) {
            anim.SetTrigger("Die");
        }
        yield return new WaitForSeconds(1);
        anim.SetTrigger("FadeOut");
    }

    public void SwitchRenderer() {
        if (thisSpriteRenderer.enabled == true) {
            thisSpriteRenderer.enabled = false;
        } else {
            thisSpriteRenderer.enabled = true;
        }
    }
}
