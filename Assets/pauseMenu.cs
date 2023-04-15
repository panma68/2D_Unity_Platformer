using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class pauseMenu : MonoBehaviour
{
    public GameObject menuUI;

    private static bool isPaused = false;
    private GameMaster gm;

    [SerializeField] private AudioMixer audioMixer;

    void Start()
    {
        menuUI.SetActive(false);
        gm = FindObjectOfType<GameMaster>();
        
        PlayerPrefs.SetInt("paused", 1);
    }

    void Update()
    {
        // 0 is paused , 1 is while playing
        if (Input.GetKeyDown(KeyCode.Escape) && PlayerPrefs.GetInt("paused") == 1)
        {
            Pause(); 
        }
    }

    public void Resume()
    {
        PlayerPrefs.SetInt("paused", 1);
        menuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        PlayerPrefs.SetInt("paused", 0);
        menuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);

    }
    public void RestartLevel()
    {
        Time.timeScale = 1f;
        gm.RestartLevel();
    }
}
