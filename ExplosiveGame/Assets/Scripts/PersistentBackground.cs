using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentBackground : MonoBehaviour
{
    public static PersistentBackground instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }else{
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }




    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
