using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;



    public void TogglePause()
    {
        if (!GameIsPaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }



    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        GameIsPaused = !GameIsPaused;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = !GameIsPaused;
    }
}
