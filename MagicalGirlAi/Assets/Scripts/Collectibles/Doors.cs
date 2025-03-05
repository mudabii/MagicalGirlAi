using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {    
            if (GameObject.FindGameObjectsWithTag("Key").Length == 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}