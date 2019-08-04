using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryPlate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bagage"))
        {
            InGameUI inGameUI = FindObjectOfType<InGameUI>();
            if (inGameUI != null)
            {
                inGameUI.ShowVictoryScreen();
                ProgressViewer.instance.LevelPassed(SceneManager.GetActiveScene().name);
                ProgressViewer.instance.SaveData();
            }
            else {
                Debug.Log("InGameUI script missing on the scene");
            }
        }
    }

}
