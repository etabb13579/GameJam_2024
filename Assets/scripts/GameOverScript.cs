using UnityEngine;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Text timeText;

    private bool isGameOver;
    private float gameTime;




    void Start()
    {
        gameTime = 0f;
        isGameOver = false;
        UpdateTimeUI();
    }

    void Update()
    {
        if (!isGameOver)
        {
            gameTime += Time.deltaTime;
            UpdateTimeUI();
        }
    }

    void UpdateTimeUI()
    {
        if (timeText != null)
        {
            timeText.text = "Time: " + Mathf.Floor(gameTime / 60).ToString("00") + ":" + (gameTime % 60).ToString("00");
        }
    }

    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
}