using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //logica del daño al player y reste 1
            Destroy(gameObject);

            Debug.Log("Pega al player");
        }
        if (collision.CompareTag("Terrain"))
        {
            Destroy(gameObject);

            Debug.Log("Pega al terreno");
        }
    }
}
