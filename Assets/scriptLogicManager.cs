using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scriptLogicManager : MonoBehaviour
{

    public bool isAlive = true;

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

    public void SetAliveState(bool state)
    {
        isAlive = state;
    }

    public void GameOver()
    {
        isAlive = false;
        gameOverScreen.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        playerScore += Time.deltaTime * scoreMultiplier;
        timer += Time.deltaTime;

        if (timer > currentUpdate)
        {
        UpdateScoreText();
        currentUpdate = Random.Range(minUpdate, maxUpdate);
        timer = 0;
        }

    }
}
