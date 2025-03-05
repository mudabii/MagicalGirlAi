using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour
{
    [SerializeField] private Text scoreText;

    void Start()
    {
        int savedScore = PlayerPrefs.GetInt("SavedScore", 0);

        if (scoreText != null)
        {
            scoreText.text = "ACABASTE      CON " + savedScore.ToString()+ "PUNTOSSSSS";
        }
    }
}
