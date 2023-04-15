using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score : MonoBehaviour
{ 
    private int scoreValue;
    public TextMeshProUGUI scoreText;

    //Sound Setup
    public AudioSource src;
    public AudioClip pickupSound;

    //Particles
    public GameObject particleEffect;

    private void Start()
    {
        scoreValue = 0;
        PlayerPrefs.SetInt("score", scoreValue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ScoreItem")
        {
            //Sound
            src.clip = pickupSound;
            src.Play();

            //Particles
            Instantiate(particleEffect, collision.transform.position, Quaternion.identity);

            addScore();
            Destroy(collision.gameObject);
        }
    }

    void addScore()
    {
        scoreValue++;
        PlayerPrefs.SetInt("score", scoreValue);
        scoreText.text = scoreValue.ToString();
    }

    public void setScore(int score)
    {
        scoreValue = score;
    }

    public int getScore()
    {
        return scoreValue;
    }

}
