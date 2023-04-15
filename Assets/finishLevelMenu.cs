using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishLevelMenu : MonoBehaviour
{
    public GameObject menuUI;
    private GameMaster gm;

    //To Change level
    [SerializeField] private levelChange levelChangeRef;

    void Start()
    {
        menuUI.SetActive(false);
        gm = GameObject.FindObjectOfType<GameMaster>();
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

    public void NextLevel()
    {
        levelChangeRef.NextLevel();
    }
}
