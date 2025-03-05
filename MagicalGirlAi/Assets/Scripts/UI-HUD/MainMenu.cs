using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MainMenu : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public RawImage rawImage;

    private void Start()
    {
        videoPlayer.Prepare();
        videoPlayer.playOnAwake = false;
        rawImage.gameObject.SetActive(false);
    }

    public void Quit()
    {
        rawImage.gameObject.SetActive(true);
        rawImage.texture = videoPlayer.targetTexture;
        videoPlayer.Play();
        StartCoroutine(WaitAndQuit());
    }

    IEnumerator WaitAndQuit()
    {
        yield return new WaitForSeconds(8f);
        Application.Quit();
    }
    public void StartGame()
    {
        videoPlayer.playOnAwake = false;
        rawImage.gameObject.SetActive(false);
        SceneManager.LoadScene("Stage 1");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}
