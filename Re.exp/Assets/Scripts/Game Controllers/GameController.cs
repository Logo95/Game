using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public void StopGame()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }
    public void GoToScene(string _loadingScene)
    {
        SceneManager.LoadScene(_loadingScene);
    }
   
    public void GoToNextScene()
    {
        int nextSceneBuildIndex = (SceneManager.GetActiveScene().buildIndex + 1); 
        string nextScenePath = SceneUtility.GetScenePathByBuildIndex(nextSceneBuildIndex);
        GoToScene(TakeSceneNameFromPath(nextScenePath));
    }
    public string TakeSceneNameFromPath(string _scenePath)
    {
        string reversedSceneName = "";
        for(int i = _scenePath.Length - 7; (_scenePath[i] != '/') && (i >= 0);i--){
            reversedSceneName += _scenePath[i];
        }
        string sceneName = "";
        for(int i = reversedSceneName.Length - 1; i >=0 ;i--){
            sceneName += reversedSceneName[i];
        }
        return sceneName;
    }

}
