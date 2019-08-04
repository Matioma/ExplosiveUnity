using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    public string LevelName = "TestScene";
    public Sprite LevelTumb;

    public Sprite[] CompletedLevelImages;


    public bool LevelCompleted = false;


    private void Awake()
    {
        this.transform.GetChild(0).GetComponent<Image>().sprite = LevelTumb;

        var CompleteImage = this.transform.GetChild(1).GetComponent<Image>();
        if (LevelCompleted)
        {
            CompleteImage.sprite = CompletedLevelImages[0];
        }
        else {
            CompleteImage.sprite = CompletedLevelImages[1];
        }
    }
    

    public void LevelButtonClicked()
    {
        InGameUI test = FindObjectOfType(typeof(InGameUI)) as InGameUI;
        test.LoadLevelByName(LevelName);
        Time.timeScale = 1;
    }
}
