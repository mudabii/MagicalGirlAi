using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class GreenEnemy : MonoBehaviour
{
    public int enemyHealth = 15;

    public RandomLoot randomLoot;

    [Header("Attack")]
    public GameObject bulletPrefab;
    public float bulletSpeed = 4f;
    public float intervalTime = 1f;
    private float lastShotTime;
    public float dmgToPlayer = 1.5f;

    [Header("Range")]
    public Transform jugador;
    public float attrange = 2f;
    

    [Header("Movement")]
    public Transform pointA;
    public Transform pointB; 
    public Transform pointC;
    public Transform pointD;
    public float speed = 4f;
    public bool isDead = false;
    public Vector3 direction;

    void Start()
    {
        lastShotTime = Time.time;
        direction = pointA.position;
    }

    void Update()
    {
        if (jugador == null || isDead) return;
        transform.position = Vector3.MoveTowards(transform.position, direction, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, direction) < 0.1f)
        {
            if (direction == pointA.position)
            {
                direction = pointB.position;
            }
            else if (direction == pointB.position)
            {
                direction = pointC.position;
            }
            else if (direction == pointC.position)
            {
                direction = pointD.position;
            }
            else
            {
                direction = pointA.position;
            }
        }

        if (Vector3.Distance(transform.position, jugador.position) <= attrange)
        {
            if (Vector3.Distance(transform.position, jugador.position) > attrange)
            {
                return;
            }
            else
            {
                if (Time.time - lastShotTime >= intervalTime)
                {
                    Shoot();
                    lastShotTime = Time.time;
                }
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

    void Shoot()
    {

        Vector2 direction = (jugador.position - transform.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.velocity = direction * bulletSpeed;
        }
    }
}
