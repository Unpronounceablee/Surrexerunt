using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    //Written by: Oscar Wadmark (su16b)     Edited by: Simon Hansson SU16a
    [SerializeField] private int startingHealth = 100;
    [Range(0, 100)][Tooltip("Remember to set slider's max value to \"100\"")] public int currentHealth;
    [SerializeField][Tooltip("Remember to set slider's max value to \"100\"")] private Slider healthSlider;
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Image flashImage;    //Vad gör denna?
    [SerializeField] private Image damageImage;

    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;

    bool isDead;
    bool damaged;   //Vad gör denna?
   

	void Awake ()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
       
        currentHealth = startingHealth;
    }
	
	void Update ()
    {
        //healthSlider.value = currentHealth; //Uncomment to Debug!
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
