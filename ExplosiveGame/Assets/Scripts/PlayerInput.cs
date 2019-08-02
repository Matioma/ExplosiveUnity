﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public float explosionForce;

    public GameObject explosion;
    public GameObject player;

    public Canvas DefeatMenu;
    private Camera camera;

    private static bool paused;
    public Text text;
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.touches[0];
            if (touch.phase == TouchPhase.Ended)
            {
                ScreenClicked(touch.position);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ScreenClicked(Input.mousePosition);
        }
    }

    //Perfom Actions On click
    void ScreenClicked(Vector3 mousePos)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 pos2D = new Vector2(pos.x, pos.y);


        RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);

        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject.name);
            text.text = $"{hit.collider.gameObject.name}";
        }
        else {

        }


        Vector3 mousePosition = camera.ScreenToWorldPoint(mousePos);
        GameObject explode = Instantiate(explosion, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
        Destroy(explode, explode.GetComponent<Explosion>().timeToDestroy);

        Explosions.ExplosionEffect(this.gameObject, explode, explosionForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeathZone")) {
            InGameUI menuSystem = FindObjectOfType<InGameUI>();
            menuSystem.ShowDefeatMenu();
        }
    }
}