using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    public Text HighScoreText;

    public void IncrementScore(int score)
    {
        Score += score;
        ScoreText.text = Score.ToString();
    }

    public void OnBombHit()
    {
        // Break Game
        Time.timeScale = 0;

        Debug.Log("Bomb HIT");
    }
}
