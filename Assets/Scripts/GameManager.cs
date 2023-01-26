using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public int vidas;
    public int gunAmmo = 100;

    public GameObject panelPause;
    bool isPaused = false;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        panelPause.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            PauseGame();

        }

    }
    private void PauseGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);

        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }

    }
}
