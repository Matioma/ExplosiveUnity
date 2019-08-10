using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{

    private void Awake()
    {
        AdMob.reference.ShowBanner();
    }

    public void HideBanner()
    {
        if (AdMob.reference)
        {
            AdMob.reference.HideBanner();
        }
    }
}
