using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string LevelName = "TestScene";
    public Sprite LevelTumb;

    public Sprite[] CompletedLevelImages;

    public Sprite LevelNotAvailable;

    private bool levelCompleted = false;
    public bool LevelCompleted
    {
        get { return levelCompleted; }
        set
        {
            if (value != levelCompleted)
            {
                levelCompleted = value;
                OnLevelCompleted();
            }
        }
    }


    private void Awake()
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = LevelTumb;
        OnLevelCompleted();
    }

    private void Start()
    {
       
    }


    /// <summary>
    /// Updates the sprites that represent the level being finished or not
    /// </summary>
    public void OnLevelCompleted()
    {
        var CompleteImage = this.transform.GetChild(1).GetComponent<Image>();
        var DisabledImage = this.transform.GetChild(2).GetComponent<Image>();
        if (LevelCompleted)
        {
            CompleteImage.sprite = CompletedLevelImages[1];
        }
        else
        {
            CompleteImage.sprite = CompletedLevelImages[0];
        }
    }

    public void LevelButtonClicked()
    {
        InGameUI test = FindObjectOfType(typeof(InGameUI)) as InGameUI;
        test.LoadLevelByName(LevelName);
        Time.timeScale = 1;
    }
    public void LevelNotInteractable()
    {
        if (!this.GetComponent<Button>().interactable)
        {
            this.transform.GetChild(0).GetComponent<Image>().sprite = LevelTumb;
        }
        else {
            this.transform.GetChild(0).GetComponent<Image>().sprite = LevelNotAvailable;
        }
    }
}
