using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public delegate void ObjectDestroyedHandler();
    public event ObjectDestroyedHandler OnDestroyed;

    public GameObject knifeTrailPrefab;
    public float minCuttingVelocity = .001f;

    bool isCutting = false;

    Vector2 previousKnifePosition;

    GameObject currentKnifeTrail;

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    void Start() {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateKnifePosition();
        }
    }

    void StartCutting()
    {
        isCutting = true;
        currentKnifeTrail = Instantiate(knifeTrailPrefab, transform);
        previousKnifePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        currentKnifeTrail.transform.SetParent(null);
        Destroy(currentKnifeTrail, 2f);
        circleCollider.enabled = false;
    }

    void UpdateKnifePosition()
    {
        Vector2 newKnifePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newKnifePosition;

        float velocity = (newKnifePosition - previousKnifePosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }

        previousKnifePosition = newKnifePosition;
    }

    //Add points.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cabbage")
        {
            GameObject.Find("Score").transform.GetComponent<ScoreText>().Score += 10;
        } else if (collision.gameObject.tag == "Chilli")
        {
            GameObject.Find("Score").transform.GetComponent<ScoreText>().Score += 10;
        } else if (collision.gameObject.tag == "Eggplant")
        {
            GameObject.Find("Score").transform.GetComponent<ScoreText>().Score += 10;
        } else if (collision.gameObject.tag == "Garlic")
        {
            GameObject.Find("Score").transform.GetComponent<ScoreText>().Score += 10;
        } else if (collision.gameObject.tag == "Potato")
        {
            GameObject.Find("Score").transform.GetComponent<ScoreText>().Score += 10;
        }
        else
        {
            print("Error no object cutted!");
        }
    }
}
