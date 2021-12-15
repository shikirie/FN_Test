using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    [Header("Speed Variables")]
    public float minimumXSpeed;
    public float maximumXSpeed;
    public float minimumYSpeed;
    public float maximumYSpeed;

    [Header("Gameplay")]
    public float lifetime;

    void Start()
    {
        //Throw moving object upwards.
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
            Random.Range(minimumXSpeed, maximumXSpeed),
            Random.Range(minimumYSpeed, maximumYSpeed)
        );

        //Wait and destroy game objects.
        Destroy(gameObject, lifetime);
    }


}
