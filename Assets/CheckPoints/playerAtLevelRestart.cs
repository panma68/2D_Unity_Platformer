using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAtLevelRestart : MonoBehaviour
{
    private GameMaster gm;

    void Start()
    {
        gm = GameObject.FindObjectOfType<GameMaster>();
        //Set player pos after respawning first time
        transform.position = gm.getLastCheckpointPosition();
    }
}
