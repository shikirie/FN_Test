using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    public delegate void ObjectSpawnedHandler(CuttableObjects obj);
    public event ObjectSpawnedHandler OnObjectSpawned;

    [Header("Target")]
    public GameObject prefab;

    [Header("Gameplay")]
    public float interval;
    public float minimumX;
    public float maximumX;
    public float y;

    [Header("Visuals")]
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", interval, interval);
    }
    private void Spawn()
    {
        //Instantiate and position the objects.
        GameObject instance = Instantiate(prefab);
        instance.transform.position = new Vector2(
            Random.Range(minimumX, maximumX),
            y
        );

        instance.transform.SetParent(transform);

        if (OnObjectSpawned != null)
        {
            OnObjectSpawned(instance.GetComponent<CuttableObjects>());
        }

        //Set a random sprite.
        Sprite randomSprite = sprites[Random.Range(0, sprites.Length)];
        instance.GetComponent<SpriteRenderer>().sprite = randomSprite;
    }
}
