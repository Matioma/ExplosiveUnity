using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float timeToDestroy = 0.5f;
    public float Radius =5;
    public float explosionForce =500;
    public void AddForceToAllObject()
    {
        Collider2D[] objectsInArea = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (Collider2D collider in objectsInArea)
        {
            if (collider.gameObject.layer == 8)
            {
                Explosions.ExplosionEffect(collider.gameObject, this.gameObject, explosionForce);
            }
        }
    }
}
