using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    //Oscar Wadmark (su16b)
    public int startingHealth = 3;
    private int currentHealth;
    public Slider healthSlider;
  
    public Image damageImage;

    Animator anim;
    public AudioSource playerAudio;
    PlayerMovement playerMovement;

    bool isDead;
    
   

	// Use this for initialization
	void Awake ()
    {
        
        playerAudio = GetComponent<AudioSource>();
       
        currentHealth = startingHealth;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
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
