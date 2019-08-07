using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            InGameUI menuSystem = FindObjectOfType<InGameUI>();
            menuSystem.ShowDefeatMenu();
        }
    }
}
