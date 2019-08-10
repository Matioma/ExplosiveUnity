using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlickingBackground : MonoBehaviour
{
    private SpriteRenderer image;
    private double currentAlfa = 1.0f;
    private double alfaChange = 0.05f;


    private void Start()
    {
        image = GetComponent<SpriteRenderer>();
        InvokeRepeating("SetAlfa", 0.1f, 0.1f);
    }

    private void SetAlfa()
    {
        if(currentAlfa >=1 || currentAlfa <= 0)
        {
            alfaChange *= -1;
        }
        currentAlfa += alfaChange;
        Color colorVector = image.color;
        colorVector.a = (float)currentAlfa;
        image.color = colorVector;
    }
}
