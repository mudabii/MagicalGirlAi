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
    }
    void Start()
    {
        if (scoreText != null)
            scoreText.text = "Score " + score.ToString();
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
}
