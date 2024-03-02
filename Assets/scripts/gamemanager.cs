using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public GameObject gameOverCanvas;

    void Start()
    {
        // Ensure game over canvas is initially disabled
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Game over canvas reference is not set in GameOverManager.");
        }
    }

    public void ShowGameOverScreen()
    {
        // Show the game over canvas
        if (gameOverCanvas != null)
        {
            gameOverCanvas.SetActive(true);
        }
        else
        {
            Debug.LogError("Game over canvas reference is not set in GameOverManager.");
        }
    }
}
