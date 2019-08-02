using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// General explosion effects tool
/// </summary>
public class Explosions : MonoBehaviour
{
    public static void ExplosionEffect(GameObject affected, GameObject explosionSurce, float explosionForce) {
        Vector2 forceDirection = (affected.transform.position - explosionSurce.transform.position).normalized;
        float Distance = Mathf.Clamp(Vector3.Distance(affected.transform.position, explosionSurce.transform.position), 0.5f, 100000);
        affected.GetComponent<Rigidbody2D>()?.AddForce(forceDirection * explosionForce / Distance);
    }


   
}
