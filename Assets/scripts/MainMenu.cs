using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void StartGame(bool bulletHell = false)
    {
        GameManager.instance.StartGame(bulletHell);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
