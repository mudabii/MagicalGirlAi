using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static EnemyState;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Loot")]
    public RandomLoot randomLoot;

    public Transform pointA;
    public Transform pointB;
    public float speed = 5f;

    public Vector3 direction;

    public float enemyHealth = 30;
    bool isDead = false;

    public float dmgToPlayer = 1.5f;
 
    void Start()
    {
        direction = pointA.position;
    }

    void Update()
    {
        if (isDead) return;
        transform.position = Vector3.MoveTowards(transform.position, direction, speed*Time.deltaTime);

        if (Vector3.Distance(transform.position, direction) < 0.1f)
        {
            if (direction == pointA.position)
            {
                direction = pointB.position;
            }
            else
            {
                direction = pointA.position;
            }
        }
    }
    void Morir()
    {
        isDead = true;
        Destroy(gameObject, 0.2f);

        if (randomLoot != null)
        {
            LootItem droppedLoot = randomLoot.GetRandomItem();
            if (droppedLoot != null && droppedLoot.itemPrefab != null)
            {
                Instantiate(droppedLoot.itemPrefab, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject, 0.2f);
            isDead = true;
        }
    }
    public void TakesDmgB(int cantidad)
    {
        if (isDead) return;
        enemyHealth -= cantidad;

        if (enemyHealth <= 0)
        {
            Morir();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(dmgToPlayer);
            }
        }
    }
}
