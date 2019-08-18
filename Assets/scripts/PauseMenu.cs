using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static PauseMenu instance;

    GameObject pauseMenu;

    public GameObject startOver;
    public GameObject Resume;

    public float timeBeforeEnd;

	void Start ()
    {
        timeBeforeEnd = -1;
        instance = this;
        pauseMenu = transform.Find("PauseMenu").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
        if (timeBeforeEnd != -1 && timeBeforeEnd < Time.time)
            PauseGame(true);
    }

    public void PauseGame(bool finished = false)
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        startOver.SetActive(finished);
        Resume.SetActive(!finished);
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu", LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void StartOver()
    {
        SceneManager.LoadScene("game", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
