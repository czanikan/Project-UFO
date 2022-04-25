using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isGameOn = true;

    private void Awake()
    {
        pausePanel.SetActive(false);
        isGameOn = true;
        Time.timeScale = 1;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isGameOn = !isGameOn;

            if (isGameOn) Resume();
            if (!isGameOn) Pause();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        isGameOn = true;
        pausePanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
