using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score instance; // create singleton of Score

    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI gameOverScoreText;
    [SerializeField] private TextMeshProUGUI gameOverHighScoreText;
    [SerializeField] private GameObject[] medals;
    [SerializeField] private TextMeshProUGUI trophyText;



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

        if (score == 50)
        {
            PipeSpawner.instance.IncreaseDifficulty();
        }
        if (score == 100)
        {
            PipeSpawner.instance.IncreaseDifficulty();
            PipeSpawner.instance.ChangePipeColor();
            //Bronze Medal
            medals[1].SetActive(true);
            medals[0].SetActive(false);
            trophyText.text = "Bronze";
        }
        if (score == 200)
        {
            PipeSpawner.instance.IncreaseDifficulty();
            //Silver Medal
            medals[2].SetActive(true);
            medals[1].SetActive(false);
            trophyText.text = "Silver";
        }
        if (score == 300)
        {
            PipeSpawner.instance.ChangePipeColor();
            //Gold Medal
            medals[3].SetActive(true);
            medals[2].SetActive(false);
            trophyText.text = "Gold";
        }
        if (score == 400)
        {
            PipeSpawner.instance.IncreaseDifficulty();
        }
        if (score == 500)
        {
            //Ruby Medal
            medals[4].SetActive(true);
            medals[3].SetActive(false);
            trophyText.text = "Ruby";
        }
        if (score == 1000)
        {
            PipeSpawner.instance.ChangePipeColor();
            //Rainbow Medal
            medals[5].SetActive(true);
            medals[4].SetActive(false);
            trophyText.text = "Rainbow";
        }
    }

    public int GetCurrentScore()
    {
        return score;
    }
}
