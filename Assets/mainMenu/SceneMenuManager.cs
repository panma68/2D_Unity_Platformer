using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject levels;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(true);
        levels.SetActive(false);

        Debug.Log("menu false, levels false");
    }
}
