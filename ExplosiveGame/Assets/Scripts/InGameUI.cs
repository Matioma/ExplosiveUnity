﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class InGameUI : MonoBehaviour, IMenu
{
    public Canvas mainMenuCanvas;
    public Canvas defeatCanvas;
    public Canvas loadScreenCanvas;
    
    private bool loading = false;
    public bool gamePaused =false;

    // Start is called before the first frame update
    private void Awake()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        defeatCanvas.gameObject.SetActive(false);
        loadScreenCanvas.gameObject.SetActive(false);
    }

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
        loading = true;
        loadScreenCanvas.gameObject.SetActive(true);
    }


    //
    public void RestartLevel()
    {
        ShowLoadScreen();
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().name));
        Time.timeScale = 1;
    }

    private IEnumerator LoadLevel(string Name)
    {
        string CurrentSceneName = SceneManager.GetActiveScene().name;
        AsyncOperation async = SceneManager.LoadSceneAsync(Name);

        while (!async.isDone) {
            Debug.Log(async.progress);
            yield return null;
        }
    }
}