using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    
    public GameObject PauseMenuUI;
    public GameObject PauseBtn;
    public GameObject InventBtn;
    public GameObject Joyst;
    public static bool GameIsPaused = false;

    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        PauseBtn.SetActive(false);
        InventBtn.SetActive(false);
        Joyst.SetActive(false);
        Time.timeScale = 1f;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResumeGame()
    {
        PauseMenuUI.SetActive(false);
        PauseBtn.SetActive(true);
        InventBtn.SetActive(true);
        Joyst.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ExitInMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
