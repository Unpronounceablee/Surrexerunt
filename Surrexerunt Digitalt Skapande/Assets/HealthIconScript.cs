using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIconScript : MonoBehaviour {

    Animator anim;
    SpriteRenderer thisSpriteRenderer;
    PlayerMovement playerMovement;
    bool isEnabled;

    [SerializeField] int index;

    private void Awake() {
        anim = gameObject.GetComponent<Animator>();
        thisSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        playerMovement = FindObjectOfType<PlayerMovement>();
        if (playerMovement.health >= index) 
            thisSpriteRenderer.enabled = true;
    }

    private void OnEnable() {
        if (playerMovement.health >= index)
            thisSpriteRenderer.enabled = true;
    }

    private void Update() {
        if (gameObject.activeSelf) {
            StartCoroutine(Display());
        }
    }

    IEnumerator Display() {
        if (playerMovement.health < index) {
            anim.SetTrigger("Die");
        }
        yield return new WaitForSeconds(2);
        anim.SetTrigger("FadeOut");
    }

    public void DisableRenderer() {
        thisSpriteRenderer.enabled = false;
    }

    private void DisableSelf() {
        gameObject.SetActive(false);
    }

    public void ResetIcons() {
        thisSpriteRenderer.enabled = true;
    }
}
