using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
<<<<<<< HEAD
    //Oscar Wadmark (su16b)
    public int startingHealth = 3;
    private int currentHealth;
    public Slider healthSlider;
  
    public Image damageImage;
=======
    
    //Written by: Oscar Wadmark (su16b)     Edited by: Simon Hansson SU16a
    [SerializeField] private int startingHealth = 100;
    [Range(0, 100)][Tooltip("Remember to set slider's max value to \"100\"")] public int currentHealth;
    [SerializeField][Tooltip("Remember to set slider's max value to \"100\"")] private Slider healthSlider;
    [SerializeField] private float flashSpeed = 5f;
    [SerializeField] private Image flashImage;    //Vad gör denna?
    [SerializeField] private Image damageImage;
>>>>>>> 41ba883fee9a7f63f7325bfb0f5d095886f3be60

    Animator anim;
    public AudioSource playerAudio;
    PlayerMovement playerMovement;

    bool isDead;
<<<<<<< HEAD
    
=======
    bool damaged;   //Vad gör denna?
>>>>>>> 41ba883fee9a7f63f7325bfb0f5d095886f3be60
   

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
