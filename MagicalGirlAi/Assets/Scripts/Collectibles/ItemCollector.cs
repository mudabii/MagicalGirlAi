using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    public int points;
    [SerializeField] private bool givesPoints;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (givesPoints)
            {
                ScoreManager.instance.AddPoints(points);
            }
            Destroy(gameObject);
        }
    }
}