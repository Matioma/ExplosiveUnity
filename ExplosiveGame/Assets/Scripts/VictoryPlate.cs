using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            }
            else {
                Debug.Log("InGameUI script missing on the scene");
            }
        }
    }

}
