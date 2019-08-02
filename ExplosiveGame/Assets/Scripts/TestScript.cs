using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public Text text;

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("clicked");
        text.text = "clicked"+ Time.deltaTime;
    }




}
