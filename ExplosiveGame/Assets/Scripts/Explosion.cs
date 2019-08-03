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

        Debug.Log(objectsInArea.Length);
        // Debug.Log(Physics2D.OverlapCircleAll(transform.position, Radius, LayerMask.NameToLayer("ForceAffected")).Length);
        //Debug.Log("GG");
        foreach (Collider2D collider in objectsInArea)
        {
            if (collider.gameObject.layer == 8)
            {
                Explosions.ExplosionEffect(collider.gameObject, this.gameObject, explosionForce);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("GG");
    }


}
