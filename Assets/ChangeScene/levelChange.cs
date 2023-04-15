using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class levelChange : MonoBehaviour
{
    public int sceneIndex;
    public GameMaster gm;
    public float nextLevelX ,nextLevelY;

    //Sound Setup
    public AudioSource src;
    public AudioClip finishLevelSound;

    [SerializeField] private GameObject timeScoreUI;
    [SerializeField] private GameObject finalScoreUI;

    //Final Score
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;


    private void Start()
    {
        gm = FindObjectOfType<GameMaster>();
        timeScoreUI.SetActive(true);
        finalScoreUI.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Sound
            src.clip = finishLevelSound;
            src.Play();

            //Score and Highscore
            float timeScore = PlayerPrefs.GetFloat("timeScore")* 10.0f;
            int scoreItems = PlayerPrefs.GetInt("score");

            timeScore = timeScore/(scoreItems+1);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            string highscoreString = "highscore" + currentSceneIndex.ToString();

            if (timeScore < PlayerPrefs.GetFloat(highscoreString, 999999999999))
            {
                PlayerPrefs.SetFloat(highscoreString, timeScore);
            }

            highScoreText.text = PlayerPrefs.GetFloat(highscoreString).ToString("0.000");
            finalScoreText.text = timeScore.ToString("0.000");


            finalScoreUI.SetActive(true);
            timeScoreUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void NextLevel()
    {
        Debug.Log("NextLevel Pressed");
        timeScoreUI.SetActive(false);
        finalScoreUI.SetActive(true);

        Time.timeScale = 1f;

        gm.set_lastCheckpointPosition(new Vector2(nextLevelX, nextLevelY));
        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

}
