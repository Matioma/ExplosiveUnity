using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void Destroyed()
    {
        Destroy(this.gameObject);
    }
}
