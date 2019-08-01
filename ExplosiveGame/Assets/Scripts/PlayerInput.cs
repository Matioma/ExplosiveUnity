using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float explosionForce;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Ended)
            {
                ScreenClicked(touch);
            }
        }
    }
    void ScreenClicked(Touch touch)
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * explosionForce);
    }
}
