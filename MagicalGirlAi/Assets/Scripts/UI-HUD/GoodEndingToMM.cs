using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GoodEndingToMM : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)|| Input.GetMouseButtonDown(0))
        {
            LoadMainMenu();
        }
    }
    void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}

