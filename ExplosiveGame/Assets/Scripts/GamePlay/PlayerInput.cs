using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class PlayerInput : MonoBehaviour
{
    public static PlayerInput instance;

    public float explosionForce;

    public GameObject explosion;
    public GameObject player;


    private Camera camera;


    public int ShotLeft = 5;
    public TextMeshProUGUI displayShotTextPro;

    private static bool paused;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else {
            Destroy(this);
        }

        displayShotTextPro.GetComponent<TextMeshProUGUI>().text = $"Shots Left: {ShotLeft}";
    }
    void Start()
    {
        camera = Camera.main;
    }
    void Update()
    {
        if (Time.timeScale == 0){
            paused = true;
        } else {
            paused = false;
        }

#if UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && Time.timeScale != 0 && ShotLeft > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.touches[0].fingerId))
            {
                return;
            }
            ScreenClicked(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y));
        }
#endif
#if UNITY_EDITOR
        if (Time.timeScale != 0 && Input.GetMouseButtonUp(0) && ShotLeft > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            ScreenClicked(Input.mousePosition);
        }
#endif
        if (ShotLeft <= 0)
        {
            Invoke("lostOutOfAmmo", 3);
        }

    }
    /// <summary>
    /// Performs actions based on the click position
    /// </summary>
    /// <param name="mousePos"></param>
    void ScreenClicked(Vector3 mousePos)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 pos2D = new Vector2(pos.x, pos.y);


        RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);

        if (hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("DeathZone"))
            {
                Debug.Log(hit.collider.gameObject.name);

            }
            else if (hit.collider.gameObject.CompareTag("DestructableObject"))
            {
                hit.collider.gameObject.GetComponent<DestructableObject>()?.Destroyed();
                CreateExplosion(mousePos);
            }
            else if (hit.collider.gameObject.CompareTag("Player") || hit.collider.gameObject.CompareTag("Bagage"))
            {
            }
            else {
                CreateExplosion(mousePos);
            }
        }
        else {
            CreateExplosion(mousePos);
        }

    }

    /// <summary>
    /// Creates the explosion object and adds force to this object
    /// </summary>
    /// <param name="_mousePosition"></param>
    private void CreateExplosion(Vector3 _mousePosition)
    {
        Vector3 mousePosition = camera.ScreenToWorldPoint(_mousePosition);
        GameObject explode = Instantiate(explosion, new Vector3(mousePosition.x, mousePosition.y, 0), Quaternion.identity);
        Destroy(explode, explode.GetComponent<Explosion>().timeToDestroy);

        explode.GetComponent<Explosion>().AddForceToAllObject();
        ReduceShotLeftCount();
    }

    public void ReduceShotLeftCount()
    {
        ShotLeft--;
        displayShotTextPro.GetComponent<TextMeshProUGUI>().text = $"Shots Left: {ShotLeft}";
    } 

    public void lostOutOfAmmo()
    {
        InGameUI menuSystem = FindObjectOfType<InGameUI>();
        menuSystem.ShowDefeatMenu();
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
