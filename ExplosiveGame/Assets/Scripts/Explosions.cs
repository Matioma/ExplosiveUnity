using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// General explosion effects tool
/// </summary>
public class Explosions : MonoBehaviour
{

    /// <summary>
    ///  Adds the force on an afected object from the explosition object with a defined force
    /// </summary>
    /// <param name="affected"> Object that is going to get force</param>
    /// <param name="explosionSurce"> GameObject that creates the exlposion effect</param>
    /// <param name="explosionForce"> The explosion force</param>
    public static void ExplosionEffect(GameObject affected, GameObject explosionSurce, float explosionForce) {
        Vector2 forceDirection = (affected.transform.position - explosionSurce.transform.position).normalized;
        float Distance = Mathf.Clamp(Vector3.Distance(affected.transform.position, explosionSurce.transform.position), 0.5f, 100000);
        affected.GetComponent<Rigidbody2D>()?.AddForce(forceDirection * explosionForce / Distance);
    }


   
}
