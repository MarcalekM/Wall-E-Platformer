using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public GameObject GameOverUI;
    public GameObject WinUI;

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void Win()
    {
        WinUI.SetActive(true);
    }

    public void Next()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
