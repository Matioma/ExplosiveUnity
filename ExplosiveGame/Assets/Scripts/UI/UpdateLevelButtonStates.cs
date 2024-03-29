﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevelButtonStates : MonoBehaviour
{
    public GameObject[] levelButtons;


    public Sprite test;
    private void Awake()
    {
        //levelButtons = this.transform.GetComponentsInChildren<LevelButton>();
    }
    private void OnEnable()
    {
        UpdateStates();
    }

    private void Start()
    {
    }


    public void UpdateStates()
    {
        Level[] progressViewerLevels = ProgressViewer.instance.playableLevels;

        foreach (GameObject LevelButton in levelButtons)
        {
            foreach (Level level in progressViewerLevels)
            {
                if (level.SceneName.Equals(LevelButton.GetComponent<LevelButton>().LevelName))
                {
                    LevelButton.GetComponent<LevelButton>().LevelCompleted = level.SceneWon;
                }
            }
        }

        for (int i = 1; i < levelButtons.Length; i++)
        {
            
            if (levelButtons[i - 1].GetComponent<LevelButton>().LevelCompleted) {
                levelButtons[i].GetComponent<Button>().interactable = true;
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(false);
            }
            else{
                levelButtons[i].GetComponent<Button>().interactable = false;
                levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
            }
        }
    }
}
