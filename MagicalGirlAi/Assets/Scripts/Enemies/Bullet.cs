using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float enemydmg = 1;
    [SerializeField] public float lifeTime = 2f;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Health>().TakeDamage(enemydmg);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
    }
}
