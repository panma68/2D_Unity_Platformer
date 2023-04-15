using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 2;
    
    [SerializeField] private Rigidbody2D rb;
    
    private GameMaster gm;

    //Particle
    [SerializeField] private GameObject deathParticles;
    
    //Death Animation
    [SerializeField] private Animator animator;

    private void Start()
    {
        health = maxHealth;
        animator.SetBool("isDead", false);
        gm = FindObjectOfType<GameMaster>();
    }

    public void TakeDamage(int amountOfDamage)
    {
        health -= amountOfDamage;
        
        if(health <= 0)
        {
            //Play death animation
            animator.SetBool("isDead", true);

            //Make when dead not able to move
            rb.bodyType = RigidbodyType2D.Static;

            //Play death particles
            Instantiate(deathParticles, transform.position, Quaternion.identity);
            
            //Starting Coroutine 
            StartCoroutine(waitForDeathAnimation());

        }
    }

    IEnumerator waitForDeathAnimation()
    {
        yield return new WaitForSeconds(1);
        gm.RestartLevel();
    }

}
