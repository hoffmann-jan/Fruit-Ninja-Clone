using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const string HighScoreKey = "HighScore";

    [Header("Score Elements")]
    public int Score;
    public Text ScoreText;
    public int HighScore;
    public Text HighScoreText;

    [Header("Game Over Elements")]
    public GameObject GameOverPanel;


    private void Awake()
    {
        GameOverPanel.SetActive(false);
        SetHighScore();
    }

    public void IncrementScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();

        if (Score > HighScore)
        {
            HighScore = Score;
            PlayerPrefs.SetInt(HighScoreKey, HighScore);
        }
    }

    public void OnBombHit()
    {
        // Break Game
        Time.timeScale = 0;
        GameOverPanel.SetActive(true);
        Debug.Log("Bomb HIT");
    }

    public void RestartGame()
    {
        Score = 0;
        ScoreText.text = "0";

        DeleteAllInteractables();
        SetHighScore();

        GameOverPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void DeleteAllInteractables()
    {
        foreach (var interactable in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            Destroy(interactable);
        }

    }

    void SetHighScore()
    {
        HighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        HighScoreText.text = "Best: " + HighScore.ToString();
    }
}
