using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject PauseMenuUI;
    public GameObject Buttons;
    public static bool GameIsPaused = false;

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Buttons.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        Buttons.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ExitInMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
