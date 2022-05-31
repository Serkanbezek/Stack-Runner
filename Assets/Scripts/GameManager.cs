using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    public bool IsGameActive = false;
    public bool IsLevelFinished = false;
    public TextMeshProUGUI ScoreText;
    public int Score;

    private void Start()
    {
        Score = 0;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void UpdateScore(int scoreToAdd)
    {
        Score += scoreToAdd;
        ScoreText.text = "Score: " + Score;
    }

}
