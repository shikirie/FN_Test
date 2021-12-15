using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableObjects : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Identifiy object by tag.
        if (collision.gameObject.tag == "Cut")
        {
            Destroy(gameObject);
        }
    }


}
