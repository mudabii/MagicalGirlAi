using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Doors : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colisión detectada con: " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El objeto que colisionó es el jugador.");
            if (GameObject.FindGameObjectsWithTag("Key").Length == 0)
            {
                Debug.Log("No hay llaves en la escena. Cambiando a la escena 3...");
                SceneManager.LoadScene(3);
            }
        }
    }
}