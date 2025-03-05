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
        Cursor.visible = false;
        videoPlayer.Prepare();
        Invoke("LoadMainMenu", 59f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(0))
        {
            LoadMainMenu();
        }
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
