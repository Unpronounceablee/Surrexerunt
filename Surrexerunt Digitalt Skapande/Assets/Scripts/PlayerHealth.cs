using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    //Oscar Wadmark (su16b)
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public float flashSpeed = 5f;
    public Image flashImage;
    public Image damageImage;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;

    bool isDead;
    bool damaged;
   

	// Use this for initialization
	void Awake ()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
       
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        playerAudio.Play();

        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    void Death()
    {
        isDead = true;

        anim.SetTrigger("Död");

        //playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovement.enabled = false;
    }
}
