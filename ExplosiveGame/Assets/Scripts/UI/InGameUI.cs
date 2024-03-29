﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameUI : MonoBehaviour, IMenu
{
   



    public Canvas[] canvasesUsed;


    public Canvas mainMenuCanvas;
    public Canvas defeatCanvas;
    public Canvas loadScreenCanvas;
    public Canvas victoryCanvas;
    
    //private bool loading = false;
    [HideInInspector]public bool gamePaused =false;


    public bool hideCanvasObject = true;
    // Start is called before the first frame update
    private void Awake()
    {

        if (hideCanvasObject) {
            mainMenuCanvas.gameObject.SetActive(false);
            defeatCanvas.gameObject.SetActive(false);
            loadScreenCanvas.gameObject.SetActive(false);
            victoryCanvas.gameObject.SetActive(false);
        }
        Time.timeScale = 1;
    }

    /// <summary>
    /// toggles the Main menu between paused and playing
    /// </summary>
    public void ToggleMainMenu()
    {
        gamePaused = !gamePaused;
        mainMenuCanvas.gameObject.SetActive(gamePaused);
        if (gamePaused) Time.timeScale = 0;
        else Time.timeScale = 1;
    }

    public void ShowDefeatMenu()
    {
        defeatCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
 
    public void ShowLoadScreen()
    {
        //loading = true;
        loadScreenCanvas.gameObject.SetActive(true);
    }

    public void RestartLevel()
    {
        ShowLoadScreen();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().name));
    }
    public void ShowVictoryScreen()
    {
        victoryCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DisplayCanvas(Canvas canvasObject)
    {
        canvasObject.gameObject.SetActive(true);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }




    public void LoadLevelByName(string MainMenuName)
    {
        ShowLoadScreen();
        StartCoroutine(LoadLevel(MainMenuName));
    }

    /// <summary>
    /// Loads Asycroniously a level with a name
    /// </summary>
    /// <param name="Name">The name of the level that has to be loaded</param>
    /// <returns></returns>
    private IEnumerator LoadLevel(string Name)
    {
        //string CurrentSceneName = SceneManager.GetActiveScene().name;
        AsyncOperation async = SceneManager.LoadSceneAsync(Name);

        while (!async.isDone) {
            yield return null;
        }
    }
}
