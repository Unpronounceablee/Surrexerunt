using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    //Oscar Wadmark (su16b)
   
  
   
    
    //Written by: Oscar Wadmark (su16b)     Edited by: Simon Hansson SU16a
    [SerializeField] private int startingHealth = 100;
    [Range(0, 100)][Tooltip("Remember to set slider's max value to \"100\"")] public int currentHealth;
    [SerializeField][Tooltip("Remember to set slider's max value to \"100\"")] private Slider healthSlider;
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Image flashImage;    //Vad gör denna?
    [SerializeField] private Image damageImage;


    Animator anim;
    public AudioSource playerAudio;
    PlayerMovement playerMovement;

    bool isDead;

    

    

   

	void Awake ()
    {
        
        playerAudio = GetComponent<AudioSource>();
       
        currentHealth = startingHealth;
    }
	
	void Update ()
    {
        //healthSlider.value = currentHealth; //Uncomment to Debug!
    }

    public void TakeDamage (int amount)
    {
        
        

        currentHealth -= amount;

        healthSlider.value = currentHealth;
        
        if(currentHealth <= 0 && !isDead)
        {
            Death ();
        }
    }

    void Death()
    {
        isDead = true;

        
        

        playerMovement.enabled = false;
    }
}
