using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int points;
    [SerializeField] private bool givesPoints;
    [SerializeField] private GameObject pinkDoor;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (givesPoints)
            {
                ScoreManager.instance.AddPoints(points);
            }
            if (gameObject.CompareTag("Key") && pinkDoor != null)
            {
                pinkDoor.SetActive(true);
            }
            Destroy(gameObject);
        }
    }
}