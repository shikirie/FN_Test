using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static bool isOver = false;

    [Header("User Interface")]
    public GameObject gameOverUI;
    public GameObject scoreTextUI;
    public GameObject timerTextUI;

    void Start()
    {
        gameOverUI.SetActive(false);
        Time.timeScale = 1f;
        isOver = false;
    }

    void Update()
    {
        if (Timer.timeLeft <= 0)
        {
            isOver = true;
            Timer.timeLeft = 1;
            Time.timeScale = 0f;
            timerTextUI.SetActive(false);
            gameOverUI.SetActive(true);

            Text gameOverText = gameOverUI.GetComponentInChildren<Text>();
            int score = GameObject.Find("Score").transform.GetComponent<ScoreText>().Score;
            gameOverText.text = string.Format(gameOverText.text, score);


            scoreTextUI.SetActive(false);
        }
    }

    public void GoToMainMenu()
    {
        isOver = false;
        Time.timeScale = 1f;
        Timer.timeLeft = 10f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReplyGame()
    {
        Time.timeScale = 1f;
        Timer.timeLeft = 10f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isOver = false;
    }
}
