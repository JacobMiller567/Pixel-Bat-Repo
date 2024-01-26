using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Configuration;

public class Score : MonoBehaviour
{
    public static Score instance; // create singleton of Score

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] private GameObject[] medals;
    [SerializeField] private TextMeshProUGUI trophyText;
    [SerializeField] private AudioSource trophyAudio;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        //PlayerPrefs.SetInt("HighScore", 0);
    }

    private void Start()
    {
        currentScoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        gameOverHighScoreText.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
        UpdateHighScore();
    }

    private void UpdateHighScore() // CHANGE this to save to leaderboard
    {
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
            highScoreText.text = score.ToString();
            gameOverHighScoreText.text = score.ToString();
        } 
    }

    public void UpdateScore()
    {
        score++;
        currentScoreText.text = score.ToString();
        gameOverScoreText.text = score.ToString();
        UpdateHighScore();

        if (score == 30)
        {
            PipeSpawner.instance.IncreaseDifficulty();
        }
        if (score == 50)
        {
            PipeSpawner.instance.ChangePipeColor();
            //Bronze Medal
            medals[1].SetActive(true);
            medals[0].SetActive(false);
            trophyText.text = "Bronze";
            trophyAudio.Play();
        }
        if (score == 100)
        {
            PipeSpawner.instance.IncreaseDifficulty();
        }
        if (score == 150)
        {
            PipeSpawner.instance.ChangePipeColor();
            //Silver Medal
            medals[2].SetActive(true);
            medals[1].SetActive(false);
            trophyText.text = "Silver";
            trophyAudio.Play();
        }
        if (score == 200)
        {
            PipeSpawner.instance.IncreaseDifficulty();
        }
        if (score == 300)
        {
            PipeSpawner.instance.IncreaseDifficulty();
            //Gold Medal
            medals[3].SetActive(true);
            medals[2].SetActive(false);
            trophyText.text = "Gold";
            trophyAudio.Play();
        }
        if (score == 500)
        {
            PipeSpawner.instance.IncreaseDifficulty();
            PipeSpawner.instance.ChangePipeColor();
            //Ruby Medal
            medals[4].SetActive(true);
            medals[3].SetActive(false);
            trophyText.text = "Ruby";
            trophyAudio.Play();
        }
        if (score == 750)
        {
            // Change ground sprite??
        }
        if (score == 1000)
        {
            //Rainbow Medal
            medals[5].SetActive(true);
            medals[4].SetActive(false);
            trophyText.text = "Rainbow";
            trophyAudio.Play();
        }
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
