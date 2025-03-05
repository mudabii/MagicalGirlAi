using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [SerializeField] private Text scoreText;
    private int score = 0;

    private void Awake()
    {
        instance = this;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); 
        }
    }
    void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score " + score.ToString();
        }
    }


    public void AddPoints(int points)
    {
        score += points;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = "Score " + score.ToString();
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("SavedScore", score);
        PlayerPrefs.Save();
    }

    public int GetScore()
    {
        return score;
    }
}
