using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_GameManager : MonoBehaviour {

    public static Menu_GameManager instance;
    public GameObject UI;
    public GameObject levelComplete;
    public GameObject gameOver;
    public GameObject gamePause;
    public GameObject loading;

	void Awake () {
        instance = this;
        UI.SetActive(true);
        levelComplete.SetActive(false);
        gameOver.SetActive(false);
        gamePause.SetActive(false);
        loading.SetActive(false);
	}
	
    public void Pause()
    {
        if(Time.timeScale == 1)
        {
            gamePause.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            gamePause.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        loading.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        loading.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
	
    public void ShowGameOver()
    {
        StartCoroutine(ShowMenu(1, gameOver));
    }

    public void ShowLevelComplete()
    {
        StartCoroutine(ShowMenu(1, levelComplete));
    }

    public void NextLevel()
    {
        loading.SetActive(true);
        GlobalValue.levelPlaying++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ShowMenu(float time, GameObject Menu)
    {
        yield return new WaitForSeconds(time);
        Menu.SetActive(true);
    }

}
