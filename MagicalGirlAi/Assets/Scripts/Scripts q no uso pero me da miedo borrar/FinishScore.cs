using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScore : MonoBehaviour
{
    public GameObject currentScore;
    private TextMesh txtcurrentScore;


    void Start()
    {
        txtcurrentScore = GetComponent<TextMesh>();
        txtcurrentScore.text = PlayerPrefs.GetString("currentScore");
    }
}
