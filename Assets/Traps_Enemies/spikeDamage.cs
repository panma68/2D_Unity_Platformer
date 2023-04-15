using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeDamage : MonoBehaviour
{
    public int damage = 1;

    //Get the method from playerHealth script
    public playerHealth player;

    //Hurt sound
    public AudioSource src;
    public AudioClip hurtSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            player.TakeDamage(damage);
            
            //Sound setup
            src.clip = hurtSound;
            src.Play();
        }
    }

}
