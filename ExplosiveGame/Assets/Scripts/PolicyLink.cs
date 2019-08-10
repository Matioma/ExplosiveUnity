using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolicyLink : MonoBehaviour
{
    public void OpenPolicy()
    {
        Application.OpenURL("https://privacypoliciesmatiomaproduction.azurewebsites.net/Policies/ExplodeTopiaPolicy.html");
    }
}
