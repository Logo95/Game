using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelOverlayController : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject countdownCanvas;
    [SerializeField] private GameObject HUDCanvas;
    [SerializeField] private GameController gameController;
    private const int COUNTDOWN_TIME = 3;
    private Text countdownText;
    private bool over = false;
    private int counter = 0;
    void Start()
    {
        gameController.StopGame();
        pauseCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        countdownCanvas.SetActive(false);
        HUDCanvas.SetActive(true);
        countdownText = countdownCanvas.GetComponentInChildren<Text>();
        StartCountdownTimer();
    }

    void Update()
    {
        checkForPause();
        
    }
    private void checkForPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !over && (counter == 0)) // counter проверяю, чтобы нельзя было нажать паузу во время отсчета или обновить таймер 
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
       gameController.GoToScene("Menu");
    }
    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
        gameController.StopGame();
    }
    public void UnPauseGame()
    {
        
        pauseCanvas.SetActive(false);
        StartCountdownTimer();  
    }
    public void StartCountdownTimer()
    {
        counter = COUNTDOWN_TIME;
        countdownCanvas.SetActive(true);
        StartCoroutine(CountdownTimer());
    }
    private IEnumerator CountdownTimer()
    {
        while(counter > 0){
            countdownText.text = counter.ToString();
            yield return new WaitForSecondsRealtime(1);
            counter--;
        }
        countdownCanvas.SetActive(false);
        gameController.StartGame();
    }
    public void onGameOver()
    {
        gameController.StopGame();
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
    }
    public void onBtnRestart()
    {
        gameController.GoToScene(SceneManager.GetActiveScene().name);
    }
    public void onBtnNextLevel()
    {
        gameController.GoToNextScene();
    }
}
