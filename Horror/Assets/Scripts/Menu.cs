using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        Application.LoadLevel("Show");
    }

    public void settings()
    {
        //settings
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
