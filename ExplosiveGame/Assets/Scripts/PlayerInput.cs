using System.Collections;
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
        //Create Explosion effect
        Vector3 worldClickPosition = camera.ScreenToWorldPoint(mousePos);
        GameObject explode =Instantiate(explosion, new Vector3(worldClickPosition.x, worldClickPosition.y, 0), Quaternion.identity);
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
