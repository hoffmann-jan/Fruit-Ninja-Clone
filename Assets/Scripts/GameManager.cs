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

    [Header("Sounds")]
    public AudioClip[] SliceSounds;
    private AudioSource AudioSource;


    private void Awake()
    {
        AudioSource = GetComponent<AudioSource>();

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

        PlayRandomSliceSound();
    }

    private void PlayRandomSliceSound()
    {
        AudioClip randomClip = SliceSounds[Random.Range(0, SliceSounds.Length)];
        AudioSource.PlayOneShot(randomClip);
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
