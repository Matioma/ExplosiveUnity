using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    public float ExplosionForce;

    public GameObject ExplositionPrefab;

    AudioSource audioSource;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if( collision.collider.gameObject.layer == 8)
        {
            collision.collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1) * ExplosionForce);
            Explosion();
        }
    }

    private void Explosion()
    {
        audioSource.PlayOneShot(audioSource.clip);
        GameObject explosionRef =Instantiate(ExplositionPrefab, this.transform.position, Quaternion.identity);
        Destroy(explosionRef.gameObject, 1.0f);
    }



}
