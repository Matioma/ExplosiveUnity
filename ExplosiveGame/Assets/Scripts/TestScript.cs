using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text text;

    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            text.text = $"position: {touch.position} + phase: {touch.phase}";
        }
    }



}
