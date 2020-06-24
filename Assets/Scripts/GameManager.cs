using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score Elements")]
    public int Score;
    public Text ScoreText;
    public Text HighScoreText;

    [Header("Game Over Elements")]
    public GameObject GameOverPanel;


    private void Awake()
    {
        GameOverPanel.SetActive(false);
    }

    public void IncrementScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
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
}
