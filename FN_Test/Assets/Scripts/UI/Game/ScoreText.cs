using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            GetComponent<Text>().text = "Score: " + score;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
