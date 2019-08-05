using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UpdateLevelButtonStates : MonoBehaviour
{
    public GameObject[] levelButtons;
    private void Awake()
    {
        //levelButtons = this.transform.GetComponentsInChildren<LevelButton>();

    }
    private void OnEnable()
    {
        UpdateStates();
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
                    //LevelButton.GetComponent<LevelButton>().OnLevelCompleted();
                }
            }
        }
    }
}
