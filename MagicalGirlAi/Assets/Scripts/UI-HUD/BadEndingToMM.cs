using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class BadEndingToMM : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer.Prepare();
        Invoke("LoadMainMenu", 59f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMainMenu();
        }
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
