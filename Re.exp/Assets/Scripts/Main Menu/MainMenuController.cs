using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject levelsCanvas;
    private GameObject currentCanvas;
    private List<GameObject> canvasQueue;
    private void Start()
    {
        mainMenuCanvas.SetActive(true);
        currentCanvas = mainMenuCanvas;
        canvasQueue = new List<GameObject>();
    }
    public void onBtnLevels(){
        mainMenuCanvas.SetActive(false);
        levelsCanvas.SetActive(true);
        canvasQueue.Add(mainMenuCanvas);
        currentCanvas = levelsCanvas;
    }
    public void onBtnBack(){
        currentCanvas.SetActive(false);
        currentCanvas = canvasQueue[canvasQueue.Count-1];
        currentCanvas.SetActive(true);
        canvasQueue.Remove(canvasQueue[canvasQueue.Count-1]);

    }
    public void onBtnToLevelTransition(Text levelName){
        SceneManager.LoadScene(levelName.text);
    }
    public void Exit()
	{
		Application.Quit ();
        
	}
}
