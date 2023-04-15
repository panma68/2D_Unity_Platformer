using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    private static GameMaster instance;

    [SerializeField]
    private Vector2 lastCheckpointPosition;

    //To reset score after dying
    [SerializeField]
    private score score;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void set_lastCheckpointPosition(Vector2 vector)
    {
        lastCheckpointPosition = vector;
    }
    public Vector2 getLastCheckpointPosition()
    {
        return lastCheckpointPosition;
    }

}
