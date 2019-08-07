using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float ExplosionForce;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.collider.gameObject.layer == 8)
        {
            collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * ExplosionForce);
        }
    }



}
