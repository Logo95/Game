using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    private Canvas canvas;
    private bool isOver = false;
    void Awake()
    {
       pauseCanvas.SetActive(false);
       gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        PauseController();
    }
    private void PauseController()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isOver)
        {
            if (pauseCanvas.activeSelf)
            {
                UnPauseGame();
            } else 
            {
                PauseGame();
            }
        }
    }
    public void onBtnMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void UnPauseGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        
        //проверить кто выиграл и в зависимости от этого вывести нужный текст
        /*
        Text gameOverText = gameOverCanvas.GetComponentInChildren<Text>();
        if(playerWon)
        {
            gameOverText.text = "Congtaulation!\nYou won!";
        }
        else
        {
            gameOverText.text = "You lost!";
        }
        */
        
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }
    public void onBtnRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
