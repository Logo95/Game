using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject gameOverCanvas;
    [SerializeField] private GameObject countdownCanvas;
    private const int COUNTDOWN_TIME = 3;
    private Text countdownText;
    private bool over = false;
    private int counter;
    void Awake()
    {
       pauseCanvas.SetActive(false);
       gameOverCanvas.SetActive(false);
       countdownCanvas.SetActive(false);
       countdownText = countdownCanvas.GetComponentInChildren<Text>();
    }

    void Update()
    {
        PauseController();
    }
    private void PauseController()
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
        counter = COUNTDOWN_TIME;
        pauseCanvas.SetActive(false);
        countdownCanvas.SetActive(true);
        StartCoroutine(Timer1());

        
    }
    private IEnumerator Timer1()
    {
        while(counter > 0){
            countdownText.text = counter.ToString();
            yield return new WaitForSecondsRealtime(1);
            counter--;
        }
        countdownCanvas.SetActive(false);
        Time.timeScale = 1;
    }
    private void Timer(float sec)
    {
        for(float timeStamp = Time.realtimeSinceStartup + sec;timeStamp > Time.realtimeSinceStartup;)
        {

        } 
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
