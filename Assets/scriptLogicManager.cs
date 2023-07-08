using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptLogicManager : MonoBehaviour
{

    public bool isAlive = true;
    public float gameSpeed = 15;
    public float maxGameSpeed = 30;

    public GameObject gameOverScreen;
    public float playerScore;
    public float scoreMultiplier = 10f;
    public Text scoreText;

    private float timer = 0;
    public float minUpdate = 0.1f;
    public float maxUpdate = 3f;
    public float currentUpdate = 1;

    public void UpdateScoreText()
    {
        scoreText.text = $"People evacuated: {(int)playerScore}";
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ManageGameSpeed()
    {
        if (playerScore > 200)
        {
            gameSpeed = 20;
        }
        if (playerScore > 500)
        {
            gameSpeed = 25;
        }
        if (playerScore > 1000)
        {
            gameSpeed = 30;
        }
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            playerScore += Time.deltaTime * scoreMultiplier;
            timer += Time.deltaTime;

            if (timer > currentUpdate)
            {
                UpdateScoreText();
                currentUpdate = Random.Range(minUpdate, maxUpdate);
                timer = 0;
            }

            ManageGameSpeed();
        }

    }
}
